using Entitites.Models;
using GraphQL;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GraphQLTests.Queries.ProgrammingLanguages
{
    public  class ProgrammingLanguageQueryTests
    {
        [Fact]
        public async Task GetProgrammingLanguages_WithLectures_ShouldReturnData()
        {
            var services = new ServiceCollection();

            services.AddDbContext<RepositoryContext>(options =>
                options.UseInMemoryDatabase("TestDbNPlusOne"));

            services
                .AddGraphQL()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();

            var provider = services.BuildServiceProvider();

            // Ubacivanje test podataka
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();

                var lecture = new Lecture { LectureName = "GraphQL" };

                var language = new ProgrammingLanguage
                {
                    LanguageName = "C#",
                    LectureProgrammingLanguages = new List<LectureProgrammingLanguage>
            {
                new LectureProgrammingLanguage
                {
                    Lecture = lecture
                }
            }
                };

                context.ProgrammingLanguages!.Add(language);
                context.SaveChanges();
            }

            var executor = await provider
                .GetRequiredService<IRequestExecutorResolver>()
                .GetRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              programmingLanguage {
                edges {
                  node {
                    languageId
                    languageName
                    languageDescription
                    languageType
                    lectureProgrammingLanguages{
                        lecture{
                            lectureName
                        }
                    }
                  }
                }
              }
            }");

            Assert.NotNull(result);

            var queryResult = result as IQueryResult;
            Assert.NotNull(queryResult);
            Assert.Null(queryResult.Errors);

            var json = result.ToJson();

            Assert.Contains("C#", json);
            Assert.Contains("GraphQL", json);
        }
    }
}
