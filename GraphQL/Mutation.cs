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

        public Mutation(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;     
            _httpClient = httpClient;
        }

<<<<<<< HEAD
        

       
=======
        public async Task<AddProgrammingLanguagePayload> AddProgrammingLanguageAsync(AddProgrammingLanguageInput input, [Service] RepositoryContext context)
        {

            var programmingLanguage = new ProgrammingLanguage
            {
                LanguageName = input.LanguageName,
                LanguageType = input.LanguageType,
                LanguageDescription = input.LanguageDescription,
            };

            if(input.SelectedLectureIds != null)
            {
                foreach (var lectureId in input.SelectedLectureIds)
                {
                    var lectureProgrammingLanguage = new LectureProgrammingLanguage
                    {                       
                        LanguageId = programmingLanguage.LanguageId,
                        LectureId = lectureId
                    };

                    if (programmingLanguage.Lectures == null)
                    {
                        programmingLanguage.Lectures = new List<LectureProgrammingLanguage>();
                    }

                    programmingLanguage.Lectures.Add(lectureProgrammingLanguage);
                }
            }
                       
            if(context.ProgrammingLanguages is not null)
            {
                context.ProgrammingLanguages.Add(programmingLanguage);
                await context.SaveChangesAsync();
            }


            return new AddProgrammingLanguagePayload(programmingLanguage);
        }

        public async Task<AddLecturePayload> AddLectureAsync(AddLectureInput input, [Service] RepositoryContext context)
        {
            
            var lecture = new Lecture
            {
                LectureName = input.LectureName,
                LectureDescription = input.LectureDescription,
            };

            if (context.Lectures is not null)
            {
                if(!context.Lectures.Any(l => l.LectureName == input.LectureName))
                {
                    context.Lectures.Add(lecture);
                    await context.SaveChangesAsync();
                }               
            }
            

            if (input.selectedProgrammingLanguageIds != null)
            {             
                foreach (var programmingLanguageId in input.selectedProgrammingLanguageIds)
                {
                    if (context.Lectures != null && context.ProgrammingLanguages != null)
                    {
                        var foundLecture = context.Lectures.FirstOrDefault(l => l.LectureName == lecture.LectureName);
                        var foundLanguage = context.ProgrammingLanguages.FirstOrDefault(pl => pl.LanguageId == programmingLanguageId);

                        if (foundLecture != null && foundLanguage != null)
                        {
                            var lectureProgrammingLanguage = new LectureProgrammingLanguage
                            {
                                LanguageId = programmingLanguageId,
                                ProgrammingLanguage = foundLanguage,
                                Lecture = foundLecture,
                                LectureId = foundLecture.LectureId,
                                
                            };

                            if(context.LectureProgrammingLanguages is not null)
                                context.LectureProgrammingLanguages.Add(lectureProgrammingLanguage);
                        }                       
                    }
                                           
                    
                }
                await context.SaveChangesAsync();
            }       
            return new AddLecturePayload(lecture);
        }
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

        public async Task<AddTestPayload?> GenerateTestExampleAsync(AddTestInput input, 
            [Service] RepositoryContext context, 
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            string inputText = $"Just return the clean JSON object. It represents a test consisting of 4 tasks which are short code examples in the {input.languageName} " +
                $"programming language, from the {input.lectureName} lesson, {input.difficultyLevel} level of difficulty, with provided options for the user to choose the correct ones. " +
                $"The number and order of correct and incorrect answers can be different for each task. " +
                $"Code examples and answers for them are also generated according to the given criteria. " +
                $"The test contains: testId (Guid ID of the test), testName (unique name of the test as a string), level (value of level is \"Intermediate\"), " +
                $"exercises (a list of tasks (exercise)). Each exercise (task) contains exerciseId (Guid ID of the task), testId (same as testId from test), " +
                $"exerciseDescription (text representing the description of the problem, i.e. the task), " +
                $"content (a string that represents the specific content of the task, i.e. a code example), and answers (a list of answers for that exercise). " +
                $"Each answer contains answerId (Guid ID of the answer), exerciseId (same as exerciseId from exercise),content (a string representing the text of the answer) and " +
                $"isCorrect (bool variable that indicates if answer is true or false).";


            ChatCompletionRequest completionRequest = new()
            {
                Model = "gpt-3.5-turbo",
                MaxTokens = 2000,
                Messages = new List<Message>() { new Message()
                                {
                                    Role = "user",
                                    Content = inputText

                                }}
            };


            using var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            httpReq.Headers.Add("Authorization", $"Bearer {_configuration.GetConnectionString("AIConnection")}");

            string requestString = System.Text.Json.JsonSerializer.Serialize(completionRequest);
            httpReq.Content = new StringContent(requestString, Encoding.UTF8, "application/json");

            using HttpResponseMessage? httpResponse = await _httpClient.SendAsync(httpReq);
            httpResponse.EnsureSuccessStatusCode();

            var completionResponse = httpResponse.IsSuccessStatusCode ? System.Text.Json.JsonSerializer.Deserialize<ChatCompletionResponse>(await httpResponse.Content.ReadAsStringAsync()) : null;

            if (completionResponse != null && context.Tests != null)
            {
                string? result = completionResponse.Choices?[0]?.Message?.Content;
                var deserializedObject = JsonConvert.DeserializeObject(result!);
                var jsonString = JsonConvert.SerializeObject(deserializedObject);
                Test? test = JsonConvert.DeserializeObject<Test>(jsonString);
                                         
                if (test is not null && context.LectureProgrammingLanguages is not null)
                {
                    var lectureProgrammingLanguage = await context.LectureProgrammingLanguages
                    .Where(lpl => lpl.LectureId == input.lectureId && lpl.LanguageId == input.languageId)
                    .FirstOrDefaultAsync();

                    if(lectureProgrammingLanguage is not null)
                        test.LectureProgrammingLanguageId = lectureProgrammingLanguage.LectureProgrammingLanguageId;
                    
                    context.Tests.Add(test);
                    await context.SaveChangesAsync(cancellationToken);

                    await eventSender.SendAsync(nameof(Subscription.OnTestAdded), test, cancellationToken);
                }
                    
                
                return new AddTestPayload(test);
                
            }
            else
                return null;
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
