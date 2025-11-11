using Contracts;
using Entitites.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ProgrammingLanguageService : IProgrammingLanguageService
    {
        private readonly IRepositoryManager _repository;

        public ProgrammingLanguageService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProgrammingLanguage>> GetAllLanguages(bool trackChanges)
        {
            try
            {
                var programmingLanguages = await _repository.ProgrammingLanguage.GetAllLanguages(trackChanges);
                return programmingLanguages;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong in the {nameof(GetAllLanguages)} service method {ex}");
                throw;
            }
        }
    }
}
