using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class ActivityParticipation
    {
        /// <summary>
        /// Defines how much this participation hast to be paid respect to a standard payment(1),
        /// for example 1.2 should be paid 20% more than a person with PaymentRatio = 1 and a person with 0.8 should be paid 20% less than a person with payment ratio = 1.
        /// </summary>
        public float PaymentRatio { get; set; }
        public string? Notes { get; set; }
        public required Activity Activity { get; set; }
        public required Guid MemberId { get; set; }
    }
}
