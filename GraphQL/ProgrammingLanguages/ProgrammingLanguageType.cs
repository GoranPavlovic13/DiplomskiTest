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
<<<<<<< HEAD
    [ExtendObjectType(typeof(ProgrammingLanguage))]
    public class ProgrammingLanguageType
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Lecture?>? Lectures(
            [Parent] ProgrammingLanguage programmingLanguage, 
            [Service] IDbContextFactory<RepositoryContext> dbContextFactory)
        {
            var context = dbContextFactory.CreateDbContext();
            return context.LectureProgrammingLanguages?
                .Where(lp => lp.LanguageId == programmingLanguage.LanguageId)
                .Select(lp => lp.Lecture)
                .AsQueryable();
        } 
=======
    public class ProgrammingLanguageType : ObjectType<ProgrammingLanguage>
    {
        protected override void Configure(IObjectTypeDescriptor<ProgrammingLanguage> descriptor)
        {
            descriptor.Description("Represents a programming language with lectures to be learned."); 
            
        }
           
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
    }
}
