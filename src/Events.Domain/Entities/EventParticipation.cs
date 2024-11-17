using Common.Domain.ValueObjects;
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
        public required Event Event { get; set; }
        public required Guid EventRoleId { get; set; }
        public required MemberKey MemberId { get; set; }
        public int Duration { get; set; }
        public string? ParticipantNotes { get; set; }
        public string? ManagerNotes { get; set; }
        public DiscordEventChannel? Channel { get; set; }
    }
}
