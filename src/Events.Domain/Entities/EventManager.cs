using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EventManagemer
    {
        /// <summary>
        /// Targert event.
        /// </summary>
        public required Event Event { get; set; }
        /// <summary>
        /// Manager of the event.
        /// </summary>
        public required Guid ManagerId { get; set; }
        /// <summary>
        /// Logbook of each manager, managers can read all the Logbooks of the event so they can lave their log of the event for next managers in long events.
        /// </summary>
        public string? Logbook { get; set; }
    }
}
