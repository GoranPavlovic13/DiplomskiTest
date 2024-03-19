﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Lectures
{
    public record AddLectureInput(string LectureName, string LectureDescription, ICollection<Guid> selectedProgrammingLanguageIds)
    {
    }
}
