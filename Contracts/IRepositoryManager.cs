using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IProgrammingLanguageRepository ProgrammingLanguage { get; }
        ILectureRepository Lecture { get; }
        //Task SaveAsync();
    }
}
