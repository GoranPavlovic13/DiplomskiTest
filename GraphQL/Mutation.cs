using Entitites.Models;
using GraphQL.Lectures;
using GraphQL.ProgrammingLanguages;
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

        public async Task<AddProgrammingLanguagePayload> AddProgrammingLanguageAsync(AddProgrammingLanguageInput input, [Service] RepositoryContext context)
        {

            var programmingLanguage = new ProgrammingLanguage
            {
                LanguageName = input.LanguageName,
                LanguageType = input.LanguageType,
                LanguageDescription = input.LanguageDescription
            };

            if(input.selectedLectureIds != null)
            {
                foreach (var lectureId in input.selectedLectureIds)
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

        public async Task<Test?> GenerateCodeExamplesAsync(string inputText, [Service] RepositoryContext context)
        {
            
            ChatCompletionRequest completionRequest = new()
            {
                Model = "gpt-3.5-turbo",
                MaxTokens = 1600,
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
                
                if(test is not null)
                {
                    context.Tests.Add(test);
                    await context.SaveChangesAsync();
                }
                    
                
                return test;

                
            }
            else
                return null;
        }


    }
}
