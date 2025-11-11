using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.ProgrammingLanguages
{
    public record UpdateProgrammingLanguageInput(Guid LanguageId, string LanguageName, LanguageType LanguageType, string LanguageDescription, ICollection<Guid> SelectedLectureIds)
    {
    }
}
