using Entitites.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
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
        }
           
    }
}
