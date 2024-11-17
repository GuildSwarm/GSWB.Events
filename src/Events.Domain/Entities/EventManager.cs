using Common.Domain.ValueObjects;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class EventManager : Entity<Guid>
    {
        /// <summary>
        /// Targert event.
        /// </summary>
        public required Event Event { get; set; }

        /// <summary>
        /// The Member id who manages the event.
        /// </summary>
        public required MemberKey MemberId { get; init; }

        /// <summary>
        /// Logbook of each manager, managers can read all the Logbooks of the event so they can lave their log of the event for next managers in long events.
        /// </summary>
        public string? Logbook { get; set; }

        internal EventManager(MemberKey memberId, Event @event, string? aLogbook = default)
        {
            this.MemberId = memberId;
            this.Event = @event;
            Logbook = aLogbook;
        }
        internal EventManager()
        {
        }
    }
}
