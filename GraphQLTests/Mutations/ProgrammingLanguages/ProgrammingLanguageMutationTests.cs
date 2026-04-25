using Entitites.Models;
using GraphQL;
using GraphQL.ProgrammingLanguages.Mutation;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GraphQLTests.Mutations.ProgrammingLanguages
{
    public class ProgrammingLanguageMutationTests
    {
        [Fact]
        public async Task AddProgrammingLanguage_ShouldCreateLanguage()
        {
            
            var services = new ServiceCollection();

            services.AddDbContext<RepositoryContext>(options =>
                options.UseInMemoryDatabase("TestDbMutation"));

            services
                .AddGraphQL()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<ProgrammingLanguageMutation>()
                .AddType<EnumType<LanguageType>>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();

            var provider = services.BuildServiceProvider();

            var executor = await provider
                .GetRequiredService<IRequestExecutorResolver>()
                .GetRequestExecutorAsync();

            // Act
            var result = await executor.ExecuteAsync(@"
                mutation {
                    addProgrammingLanguage(input: {
                    languageName: ""Python"",
                    languageType: OBJECT_ORIENTED,
                    languageDescription: ""Test description"",
                    selectedLectureIds: []
                    }) {
                        programmingLanguage {
                        languageName
                    }
                  }
                }");

            // Assert
            Assert.NotNull(result);

            var queryResult = result as IQueryResult;
            Assert.NotNull(queryResult);
            Assert.Null(queryResult.Errors);

            var json = result.ToJson();

            Assert.Contains("Python", json);

            // Provera baze
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();

                Assert.Equal(1, context.ProgrammingLanguages!.Count());
            }
        }
    }
}
