using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Answer
    {
        [Key]
        public Guid AnswerId { get; set; }
        public string? Content { get; set; }
        [ForeignKey(nameof(Exercise))]
        public Guid ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public bool IsCorrect { get; set; } 
    }
}
