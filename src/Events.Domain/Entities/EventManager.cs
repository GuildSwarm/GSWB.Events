using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class EventManager : Entity<Guid>
    {
        /// <summary>
        /// Targert event.
        /// </summary>
        public required Event Event { get; set; }

        #region MemberKey
        /// <summary>
        /// Manager of the event.
        /// </summary>
        /// <remarks>Part of MemberKey</remarks>
        public required ulong UserId { get; set; }

        /// <summary>
        /// Guild of the event.
        /// </summary>
        /// <remarks>Part of MemberKey</remarks>
        public required ulong GuildId { get; set; }
        #endregion

        /// <summary>
        /// Logbook of each manager, managers can read all the Logbooks of the event so they can lave their log of the event for next managers in long events.
        /// </summary>
        public string? Logbook { get; set; }

        internal EventManager(ulong GuildId, ulong UserId, Event Event, string? aLogbook = default)
        {
            this.GuildId = GuildId;
            this.UserId = UserId;
            this.Event = Event;
            Logbook = aLogbook;
        }
        internal EventManager()
        {
        }
    }
}
