using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EventRequirement
    {
        public Guid? RequiredRoleId { get; set; }
        public Guid? RequiredLicenseId { get; set; }
        public bool IsGameHandleVerificationRequired { get; set; }


        public virtual ICollection<EventRole> EventRoles { get; set; } = [];
        public virtual ICollection<EventRoleTemplate> EventRoleTemplates { get; set; } = [];
        public virtual ICollection<Event> Events { get; set; } = [];
        public virtual ICollection<EventTemplate> EventTemplates { get; set; } = [];
    }
}
