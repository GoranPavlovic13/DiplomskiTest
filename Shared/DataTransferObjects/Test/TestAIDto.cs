using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Test
{
    public class TestAIDto
    {
        public string TestName { get; set; } = default!;
        public string Level { get; set; } = default!;
        public List<ExerciseAIDto> Exercises { get; set; } = new();
    }
}
