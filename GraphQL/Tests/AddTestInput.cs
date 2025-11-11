using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Tests
{
    public record AddTestInput(Guid languageId, string languageName, Guid lectureId, string lectureName, string difficultyLevel)
    {
    }
}
