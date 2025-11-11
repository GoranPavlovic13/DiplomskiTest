using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProgrammingLanguageService> _programmingLanguageService;
        private readonly Lazy<ILectureService> _lectureService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _programmingLanguageService = new Lazy<IProgrammingLanguageService>(() => new ProgrammingLanguageService(repositoryManager));
            _lectureService = new Lazy<ILectureService>(() => new LectureService(repositoryManager));
        }

        public IProgrammingLanguageService ProgrammingLanguageService => _programmingLanguageService.Value;

        public ILectureService LectureService => _lectureService.Value;
    }
}
