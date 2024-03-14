using Entitites.Models;
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

        /*
        [UseProjection]
        public async Task<IQueryable<ProgrammingLanguage>> GetProgrammingLanguage([Service] RepositoryContext context)
        {
            var languages = context.ProgrammingLanguages.ToList();
            return languages.AsQueryable();
        }

        [UseProjection]
        public async Task<IQueryable<Lecture>> GetLecture([Service] RepositoryContext context)
        {
            var lectures = context.Lectures.ToList();
            return lectures.AsQueryable();
        }*/
    }
}
