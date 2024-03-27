using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EventRoleTemplate
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        /// <summary>
        /// The required count of participant to cover this role, if null it should be undertoond as "unspecified" or "Unlimited".
        /// </summary>
        public int? RequiredCount { get; set; }


        public virtual ICollection<EventRequirement> EventRequirements { get; set; } = [];
        public virtual ICollection<EventTemplate> EventTemplate { get; set; } = [];

    }
}
