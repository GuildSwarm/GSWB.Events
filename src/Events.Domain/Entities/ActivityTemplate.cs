using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class ActivityTemplate
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public EventTemplate? EventTemplate { get; set; }
    }
}
