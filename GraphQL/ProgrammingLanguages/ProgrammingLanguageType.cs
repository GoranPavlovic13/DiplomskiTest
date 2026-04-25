using Entitites.Models;
using GraphQL.DataLoaders;
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
        public async Task<IEnumerable<Lecture>> GetLecturesAsync(
        [Parent] ProgrammingLanguage language,
        LecturesByLanguageIdDataLoader dataLoader,
        CancellationToken cancellationToken)
        {
            return await dataLoader.LoadAsync(language.LanguageId, cancellationToken);
        }

    }
}
