using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EventActivity
    {
        public required Event Event { get; set; }
        public required Activity Activity { get; set; }
    }
}
