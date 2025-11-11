using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Lectures
{
    [ExtendObjectType(typeof(Lecture))]
    public class LectureType
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ProgrammingLanguage> ProgrammingLanguages(
            [Parent] Lecture lecture,
            [Service] IDbContextFactory<RepositoryContext> dbContextFactory)
        {
            var context = dbContextFactory.CreateDbContext();

            return (context.LectureProgrammingLanguages ?? Enumerable.Empty<LectureProgrammingLanguage>().AsQueryable())
        .Where(lp => lp.LectureId == lecture.LectureId)
        .Select(lp => lp.ProgrammingLanguage!)
        .AsQueryable();
        }
    }
}
