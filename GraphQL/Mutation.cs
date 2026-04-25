using AutoMapper;
using Entitites.Models;
using GraphQL.Lectures;
using GraphQL.ProgrammingLanguages;
using GraphQL.Tests;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Completions;
using Repository;
using Shared;
using Shared.DataTransferObjects.Test;
using Shared.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GraphQL
{
    public class Mutation
    {

        private readonly IConfiguration _configuration;        
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public Mutation(IConfiguration configuration, HttpClient httpClient, IMapper mapper)
        {
            _configuration = configuration;     
            _httpClient = httpClient;
            _mapper = mapper;
        }



        public async Task<AddTestPayload?> GenerateTestExampleAsync(
        AddTestInput input,
        [Service] RepositoryContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            const int maxRetries = 3;
            string? lastError = null;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                string inputText = $@"
                    Return ONLY valid JSON. No explanations, comments, markdown, or code fences.

                    JSON schema:
                    {{
                      ""testName"": ""string"",
                      ""level"": ""{input.difficultyLevel}"",
                      ""exercises"": [
                        {{
                          ""exerciseDescription"": ""string"",
                          ""content"": ""string"",
                          ""answers"": [
                            {{
                              ""content"": ""string"",
                              ""isCorrect"": true
                            }}
                          ]
                        }}
                      ]
                    }}

                    Generate 4 exercises in {input.languageName}, topic {input.lectureName}, difficulty {input.difficultyLevel}.
                    Each exercise must have at least one correct answer. The number of correct answers can vary per exercise.
                    The number and order of correct and incorrect answers can be different for each task.
                    Code examples and answers must respect the criteria above.
                    Output must be a single-line JSON string.
";

                if (lastError != null)
                    inputText += $"\nPrevious output was invalid because: {lastError}\nFix only that issue.";

                // Poziv AI
                var completionRequest = new ChatCompletionRequest
                {
                    Model = "gpt-4o-mini",
                    MaxTokens = 2000,
                    Messages = new List<Message> { new Message { Role = "user", Content = inputText } }
                };

                using var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
                httpReq.Headers.Add("Authorization", $"Bearer {_configuration.GetConnectionString("AIConnection")}");
                httpReq.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(completionRequest),
                                                   Encoding.UTF8, "application/json");

                using var httpResponse = await _httpClient.SendAsync(httpReq, cancellationToken);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    lastError = $"OpenAI API error: {httpResponse.StatusCode}";
                    continue;
                }

                var completionResponse = System.Text.Json.JsonSerializer.Deserialize<ChatCompletionResponse>(
                    await httpResponse.Content.ReadAsStringAsync(cancellationToken));

                var result = completionResponse?.Choices?.FirstOrDefault()?.Message?.Content;
                if (string.IsNullOrWhiteSpace(result))
                {
                    lastError = "Empty AI response";
                    continue;
                }

                // Extract JSON i validacija
                string? jsonError = null;
                var json = JsonHelperMethods.ExtractJson(result);
                if (json == null || !JsonHelperMethods.IsValidJson(json, out jsonError))
                {
                    lastError = jsonError ?? "Invalid JSON format";
                    continue;
                }

                // Deserijalizacija u DTO
                string? validationError = null;
                TestAIDto? dto;
                try
                {
                    dto = JsonConvert.DeserializeObject<TestAIDto>(json);
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    lastError = ex.Message;
                    continue;
                }

                if (dto == null || !JsonHelperMethods.IsValidAiTest(dto, out validationError))
                {
                    lastError = validationError;
                    continue;
                }

                // Mapiranje u EF entitet
                var test = _mapper.Map<Test>(dto);

                // FK LectureProgrammingLanguage
                var lpl = await context.LectureProgrammingLanguages!
                    .FirstOrDefaultAsync(x => x.LectureId == input.lectureId && x.LanguageId == input.languageId,
                                          cancellationToken);
                if (lpl == null)
                    throw new Exception("LectureProgrammingLanguage not found");

                test.LectureProgrammingLanguageId = lpl.LectureProgrammingLanguageId;

                context.Tests!.Add(test);
                await context.SaveChangesAsync(cancellationToken);

                await eventSender.SendAsync(nameof(Subscription.OnTestAdded), test, cancellationToken);

                return new AddTestPayload(test);
            }

            // Ako posle retry-a ne uspe → loguj, ali korisnik ne vidi stack trace
            throw new Exception("Failed to generate valid test after multiple attempts.");
        }


        public async Task<EvaluateTestPayload> EvaluateTestAsync(EvaluateTestInput input, [Service] RepositoryContext context)
        {
            var test = await context.Tests!
                .Include(t => t.Exercises!)
                .ThenInclude(e => e.Answers)
                .FirstOrDefaultAsync(t => t.TestId == input.testId);

            if (test == null)
                return new EvaluateTestPayload(false, "Test not found", 0);

            bool answersMatch = false;
            int score = 0;

            foreach(var exercise in test.Exercises!)
            {
                foreach(var answer in exercise.Answers!)
                {
                    foreach(var answerId in input.selectedAnswers!)
                    {
                        if (answer.IsCorrect && answer.AnswerId == answerId)
                        {
                            answersMatch = true;
                            break;
                        }
                            
                        else if (!answer.IsCorrect && answer.AnswerId == answerId)
                            answersMatch = false;
                    }
                }

                if(answersMatch)
                    score++;

                answersMatch = false;
            }

            if(score < 2)
                return new EvaluateTestPayload(false, "Test evaluated unsuccessfully", score);

            
            return new EvaluateTestPayload(true, "Test evaluated successfully", score);
        }
    }
}
