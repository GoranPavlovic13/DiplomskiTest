using Entitites.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.ProgrammingLanguages
{
    public class ProgrammingLanguageType : ObjectType<ProgrammingLanguage>
    {
        protected override void Configure(IObjectTypeDescriptor<ProgrammingLanguage> descriptor)
        {
            descriptor.Description("Represents a programming language with lectures to be learned.");

            descriptor
            .Field(pl => pl.Lectures)
            .ResolveWith<Resolvers>(pl => pl.GetLectures(default!, default!))
            .Description("This is the list of available lectures for this programming language.");
        }

        private class Resolvers
        {
            public IQueryable<Lecture>? GetLectures(ProgrammingLanguage programmingLanguage, [Service(ServiceKind.Pooled)] RepositoryContext context) {
                if (context.Lectures == null) 
                    return null;

                return context.Lectures
                    .Where(l => l.ProgrammingLanguages != null && l.ProgrammingLanguages.Any(pl => pl.LanguageId == programmingLanguage.LanguageId));
            }
        }
    }
}
