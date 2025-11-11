using Entitites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.ProgrammingLanguages
{
    public class AddProgrammingLanguageInput
    {
        [Required(ErrorMessage = "Programming language name is required.")]
        public string LanguageName { get; set; } = string.Empty;

        public LanguageType LanguageType { get; set; }

        public string LanguageDescription { get; set; } = string.Empty;

        public ICollection<Guid> SelectedLectureIds { get; set; } = new List<Guid>();
    }
}
