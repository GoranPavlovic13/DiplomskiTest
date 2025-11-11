using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Test OnTestAdded([EventMessage] Test test)
        {
            return test;
        }
    }
}
