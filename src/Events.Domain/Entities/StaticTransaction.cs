using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class StaticTransaction : Entity<Guid>
    {
        public float Amount { get; set; }
        public string? Reason { get; set; }

        public required ActivityParticipation Participation { get; set; }
    }
}
