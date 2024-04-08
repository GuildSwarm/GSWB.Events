using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class EventRoster : Entity<Guid>
    {
        public required string Name { get; set; }
        public string? Descriptions { get; set; }
        public ICollection<EventRole> Roles { get; set; } = [];
    }
}
