using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class EventTemplate : Entity<Guid>
    {
        /// <summary>
        /// Name of the event.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Description of the event.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Expected event duration by the event managers.
        /// </summary>
        public TimeSpan ExpectedDuration { get; set; }

        /// <summary>
        /// Scheduled event start date(determines discord channels creation time).
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The template for discord channels setup of this event.
        /// </summary>
        public DiscordEventChannelTemplate? DiscordTemplate { get; set; }


        /// <summary>
        /// List of <see cref="EventTag"/> for this EventTemplate.
        /// </summary>
        public virtual ICollection<EventTag> Tags { get; set; } = [];
        public virtual ICollection<EventRoleTemplate> EventRoleTemplates { get; set; } = [];
        public virtual ICollection<EventRequirement> Requirements { get; set; } = [];

    }
}
