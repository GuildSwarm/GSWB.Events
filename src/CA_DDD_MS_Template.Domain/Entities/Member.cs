using Events.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    //Entity class file should contain only properties and fields, business logic should be place in aonther partial class file withing the same domain.
    public partial class Member : Entity<Guid>
    {
        [MaxLength(32)]
        [MinLength(2)]
        [Required]
        public required string Name { get; set; }

        [MaxLength(32)]
        [MinLength(2)]
        [Required]
        public required string Nickname { get; set; }

        [Required]
        public required MemberType Type { get; set; }
    }
}
