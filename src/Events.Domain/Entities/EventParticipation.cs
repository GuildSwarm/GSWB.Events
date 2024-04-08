using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class EventParticipation : Entity<Guid>
    {
        public required Guid MemberId { get; set; }
        public int Duration { get; set; }
        public string? ParticipantNotes { get; set; }
        public string? ManagerNotes { get; set; }
        public required EventRole Role { get; set; }
        public DiscordEventChannel? Channel { get; set; }
    }
}
