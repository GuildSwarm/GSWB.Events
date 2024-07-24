using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class EventTag : Entity<Guid>
    {
        public required Event Event { get; set; }
        public Guid TagId { get; set; }

        internal EventTag() { }
    }
}
