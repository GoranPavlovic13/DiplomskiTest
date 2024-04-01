using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Exercise
    {
        [Key]
        public Guid ExerciseId { get; set; }
        public string? ExerciseDescription { get; set; }
        public string? Content { get; set; }
        public ICollection<Answer>? Answers { get; set; }
        [ForeignKey(nameof(Test))]
        public Guid TestId { get; set; }
        public Test? Test { get; set; }
    }
}
