using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class ParticipationRequirement : Entity<Guid>
    {
        public Guid? RequiredRoleId { get; set; }
        public Guid? RequiredLicenseId { get; set; }
        public bool IsGameHandleVerificationRequired { get; set; }


        public virtual ICollection<EventRole> EventRoles { get; set; } = [];
        public virtual ICollection<EventRoleTemplate> EventRoleTemplates { get; set; } = [];
        public virtual ICollection<EventTemplate> EventTemplates { get; set; } = [];
    }
}
