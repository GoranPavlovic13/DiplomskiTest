using Entitites.Models;

namespace Service.Contracts
{
    public interface IProgrammingLanguageService
    {
        Task <IEnumerable<ProgrammingLanguage>> GetAllLanguages(bool trackChanges);
    }
}