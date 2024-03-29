using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class Event : Entity<Guid>
    {
        public ulong DiscordEventId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// Para informar al usuario de la duración estimada.
        /// </summary>
        public TimeSpan ExpectedDuration { get; set; }

        /// <summary>
        /// Fecha de inicio prevista del evento(creacion de canales).
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Fecha de inicio del evento (triggered by manager).
        /// </summary>
        public DateTime LaunchDate { get; set; }

        /// <summary>
        /// Automatico, cuando el bot cierra el evebto, set to time now.
        /// </summary>
        public DateTime EndDate { get; set; }

        public DiscordEventChannel? DiscordTemplate { get; set; }



        public virtual ICollection<EventTag> Tags { get; set; } = [];

        public virtual ICollection<EventRequirement> EventRequirements { get; set; } = [];

    }
}
