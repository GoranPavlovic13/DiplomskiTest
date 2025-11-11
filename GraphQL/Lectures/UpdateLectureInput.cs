using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Lectures
{
    public record UpdateLectureInput(Guid LectureId, string LectureName, string LectureDescription, ICollection<Guid> selectedProgrammingLanguageIds)
    {
    }
}
