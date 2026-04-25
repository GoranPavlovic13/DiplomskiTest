using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Test
{
    public  class ExerciseAIDto
    {
        public string ExerciseDescription { get; set; } = default!;
        public string Content { get; set; } = default!;
        public List<AnswerAIDto> Answers { get; set; } = new();
    }
}
