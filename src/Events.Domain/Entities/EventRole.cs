using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class EventRole : Entity<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Slots { get; set; } = 1; //Defult value should be 1. 

        public required Event Event { get; set; }
        public ICollection<EventRoster> Rosters { get; set; } = [];
        public ICollection<EventParticipation> Participations { get; set; } = [];
        public virtual ICollection<EventRequirement> EventRequirements { get; set; } = [];
    }
}
