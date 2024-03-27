using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EventRole
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int MaxSlots { get; set; } = 1; //Defult value should be 1. 
        public virtual ICollection<EventRequirement> EventRequirements { get; set; } = [];
        public required Event Event { get; set; }
    }
}
