using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Manager of the event.
        /// </summary>
        public required Guid MemberId { get; set; }
        /// <summary>
        /// Logbook of each manager, managers can read all the Logbooks of the event so they can lave their log of the event for next managers in long events.
        /// </summary>
        public string? Logbook { get; set; }

        internal EventManager(Guid MemberId, Event Event, string? aLogbook = default)
        {
            this.MemberId = MemberId;
            this.Event = Event;
            Logbook = aLogbook;
        }
        internal EventManager()
        {
        }
    }
}
