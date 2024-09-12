using Entitites.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Repository;
namespace GraphQL
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ProgrammingLanguage>? GetProgrammingLanguage([Service] RepositoryContext context)
        {           
            return context.ProgrammingLanguages;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Lecture>? GetLecture([Service] RepositoryContext context)
        {
            return context.Lectures;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Test>? GetTest([Service] RepositoryContext context)
        {
            return context.Tests;
        }
    }
}
