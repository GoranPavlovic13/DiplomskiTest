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
<<<<<<< HEAD
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ProgrammingLanguage> GetProgrammingLanguage(
            [Service] RepositoryContext context)
        {
            return context.ProgrammingLanguages 
                ?? Enumerable.Empty<ProgrammingLanguage>().AsQueryable();
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Lecture> GetLecture(
               [Service] RepositoryContext context)
        {
            if (context.Lectures == null)
                throw new ArgumentNullException(nameof(context));

            return context.Lectures;

        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Test> GetTest([Service] RepositoryContext context)
        {
            return context.Tests 
                ?? Enumerable.Empty<Test>().AsQueryable();
=======
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
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
        }
    }
}
