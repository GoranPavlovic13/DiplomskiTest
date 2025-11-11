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

    }
}
