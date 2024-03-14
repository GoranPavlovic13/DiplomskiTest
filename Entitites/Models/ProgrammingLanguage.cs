using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class ProgrammingLanguage
    {
        [Key]
        [Column("LanguageId")]
        public Guid LanguageId { get; set; }

        [Required(ErrorMessage = "Programming language name is required.")]
        public string? LanguageName { get; set; }  
        public LanguageType? LanguageType { get; set; }
        public string? LanguageDescription { get; set; }
        public ICollection<LectureProgrammingLanguage>? Lectures { get; set; }        
    }
}
