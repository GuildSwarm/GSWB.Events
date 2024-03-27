using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class StaticTransaction
    {
        public float Amount { get; set; }
        public string? Reason { get; set; }

        public required ActivityParticipation Participation { get; set; }
    }
}
