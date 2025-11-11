using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProgrammingLanguageRepository> _programmingLanguageRepository;
        private readonly Lazy<ILectureRepository> _lectureRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _programmingLanguageRepository = new Lazy<IProgrammingLanguageRepository>(() => new
            ProgrammingLanguageRepository(repositoryContext));
            _lectureRepository = new Lazy<ILectureRepository>(() => new
            LectureRepository(repositoryContext));
        }
            public IProgrammingLanguageRepository ProgrammingLanguage => _programmingLanguageRepository.Value;
            public ILectureRepository Lecture => _lectureRepository.Value;
            //public async Task SaveAsync() => _repositoryContext.SaveChangesAsync();
        
    }
}
