using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Test
{
    public class AnswerAIDto
    {
        public string Content { get; set; } = default!;
        public bool IsCorrect { get; set; }
    }
}
