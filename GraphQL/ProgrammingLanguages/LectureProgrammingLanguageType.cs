using Entitites.Models;
using GraphQL.Lectures;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GraphQL.ProgrammingLanguages
{
    public class LectureProgrammingLanguageType : ObjectType<LectureProgrammingLanguage>
    {
        protected override void Configure(IObjectTypeDescriptor<LectureProgrammingLanguage> descriptor)
        {
            descriptor.Field(x => x.LectureProgrammingLanguageId).Type<NonNullType<UuidType>>();

            /*descriptor
                .Field("lecture")
                .ResolveWith<Resolvers>(r => r.GetLecture(default!, default!))
                .Type<LectureType>()

            descriptor
                .Field("programmingLanguage")
                .ResolveWith<Resolvers>(r => r.GetProgrammingLanguage(default!, default!))
                .Type<ProgrammingLanguageType>();*/
        }

        private class Resolvers
        {
            public Lecture? GetLecture(LectureProgrammingLanguage root, [Service] RepositoryContext context)
            {
                if (context.Lectures == null)
                    throw new ArgumentNullException(nameof(context));

                return context.Lectures
                    .FirstOrDefault(l => l.LectureId == root.LectureId);
            }

            public ProgrammingLanguage? GetProgrammingLanguage(LectureProgrammingLanguage root, [Service] RepositoryContext context)
            {
                if (context.ProgrammingLanguages == null)
                    throw new ArgumentNullException(nameof(context));

                return context.ProgrammingLanguages
                    .FirstOrDefault(p => p.LanguageId == root.LanguageId);
            }
        }
    }
}
