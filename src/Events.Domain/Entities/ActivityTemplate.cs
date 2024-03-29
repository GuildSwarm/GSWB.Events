using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class ActivityTemplate : Entity<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public EventTemplate? EventTemplate { get; set; }
    }
}
