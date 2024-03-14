using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class LectureProgrammingLanguage
    {
        public Guid LectureId { get; set; }
        public Lecture? Lecture { get; set; } 

        public Guid LanguageId { get; set; } 
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }
    }
}
