using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class LectureProgrammingLanguage
    {
        [Key]
        public Guid LectureProgrammingLanguageId { get; set; }
        public Guid LectureId { get; set; }
        public Lecture? Lecture { get; set; } 

        public Guid LanguageId { get; set; } 
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }
           
        public ICollection<Test>? Tests { get; set; }
    }
}
