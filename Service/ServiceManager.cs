using AutoMapper;
using Contracts;
using Entitites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _programmingLanguageService = new Lazy<IProgrammingLanguageService>(() => new ProgrammingLanguageService(repositoryManager));
            _lectureService = new Lazy<ILectureService>(() => new LectureService(repositoryManager));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public IProgrammingLanguageService ProgrammingLanguageService => _programmingLanguageService.Value;

        public ILectureService LectureService => _lectureService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
