using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Lecture
    {
        [Key]
        [Column("LectureId")]
        public Guid LectureId { get; set; }
        [Required(ErrorMessage = "Lecture name is required.")]
        public string? LectureName { get; set; }
        public string? LectureDescription { get; set; }
        public ICollection<LectureProgrammingLanguage>? ProgrammingLanguages { get; set; }
    }
}
