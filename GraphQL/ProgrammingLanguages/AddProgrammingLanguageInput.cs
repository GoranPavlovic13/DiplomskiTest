using Entitites.Models;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.ProgrammingLanguages
{
<<<<<<< HEAD
    public class AddProgrammingLanguageInput
    {
        [Required(ErrorMessage = "Programming language name is required.")]
        public string LanguageName { get; set; } = string.Empty;

        public LanguageType LanguageType { get; set; }

        public string LanguageDescription { get; set; } = string.Empty;

        public ICollection<Guid> SelectedLectureIds { get; set; } = new List<Guid>();
=======
    public record AddProgrammingLanguageInput(string LanguageName, LanguageType LanguageType, string LanguageDescription, ICollection<Guid> SelectedLectureIds)
    {
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
    }
}
