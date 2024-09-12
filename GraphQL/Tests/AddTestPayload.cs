using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Tests
{
    public record AddTestPayload(Test? test)
    {
    }
}
