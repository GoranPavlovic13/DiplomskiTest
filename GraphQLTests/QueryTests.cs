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

namespace GraphQLTests
{
    public class QueryTests
    {
        [Fact]
        public async Task GetProgrammingLanguage_ShouldReturnData()
        {
            // Arrange
            var services = new ServiceCollection();

            services.AddDbContext<RepositoryContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            services
                .AddGraphQL()
                .AddQueryType<Query>()
                .AddFiltering()   
                .AddSorting()
                .AddProjections();

            var provider = services.BuildServiceProvider();

            // UBACIVANJE TEST PODATAKA
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();

                context.ProgrammingLanguages!.Add(new ProgrammingLanguage
                {
                    LanguageName = "C#"
                });

                context.ProgrammingLanguages.Add(new ProgrammingLanguage
                {
                    LanguageName = "JavaScript"
                });

                context.SaveChanges();
            }

            var executor = await provider
                .GetRequiredService<IRequestExecutorResolver>()
                .GetRequestExecutorAsync();

            // Act
            var result = await executor.ExecuteAsync(@"
            {
              programmingLanguage {
                edges {
                  node {
                    languageName
                  }
                }
              }
            }");

            // Assert
            Assert.NotNull(result);

            var queryResult = result as IQueryResult;

            Assert.NotNull(queryResult);
            Assert.Null(queryResult.Errors);

            var json = result.ToJson();

            Assert.Contains("C#", json);
            Assert.Contains("JavaScript", json);
        }
    }
}
