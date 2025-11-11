using Entitites.Models;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Lectures
{
<<<<<<< HEAD
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
=======
    public class LectureType : ObjectType<Lecture>
    {
        protected override void Configure(IObjectTypeDescriptor<Lecture> descriptor)
        {
            descriptor.Description("Represents a lecture for programming language.");

            descriptor
            .Field(pl => pl.ProgrammingLanguages)
            //ResolveWith<Resolvers>(pl => pl.GetLectures(default!, default!))
            .Description("The list of programming languages to which lecture belongs.");
        }

        private class Resolvers
        {
            public IQueryable<ProgrammingLanguage>? GetProgrammingLanguages(Lecture lecture, [Service] RepositoryContext context)
            {
                if (context.ProgrammingLanguages == null)
                    return null;

                return context.ProgrammingLanguages
                    .Where(pl => pl.Lectures != null && pl.Lectures.Any(lpl => lpl.LectureId == lecture.LectureId));
            }
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
        }
    }
}
