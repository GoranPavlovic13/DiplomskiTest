using Entitites.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Lectures
{
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
        }
    }
}
