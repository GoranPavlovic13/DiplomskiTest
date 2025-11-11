using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Lectures
{
    public record DeleteLecturePayload(bool Success, Guid DeletedLectureId);
    
}
