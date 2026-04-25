using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DataLoaders
{
    public class LecturesByLanguageIdDataLoader : BatchDataLoader<Guid, IEnumerable<Lecture>>
    {
        private readonly IDbContextFactory<RepositoryContext> _dbContextFactory;

        public LecturesByLanguageIdDataLoader(
            IDbContextFactory<RepositoryContext> dbContextFactory,
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }
        [DataLoader]
        protected override async Task<IReadOnlyDictionary<Guid, IEnumerable<Lecture>>> LoadBatchAsync(
            IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using var context = _dbContextFactory.CreateDbContext();

            var result = await context.LectureProgrammingLanguages!
                .Where(lp => keys.Contains(lp.LanguageId))
                .Include(lp => lp.Lecture)
                .ToListAsync(cancellationToken);

            return result
                .GroupBy(lp => lp.LanguageId)
                .ToDictionary(g => g.Key, g => g.Select(lp => lp.Lecture!).AsEnumerable());
        }
    }
}
