using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Test
    {
        [Key]
        public Guid TestId { get; set; }
       
        public string? TestName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Level Level { get; set; }
        [ForeignKey(nameof(LectureProgrammingLanguage))]
        public Guid LectureProgrammingLanguageId { get; set; }
        public LectureProgrammingLanguage? LectureProgrammingLanguage { get; set; }

        public ICollection<Exercise>? Exercises { get; set; }
    }
}
