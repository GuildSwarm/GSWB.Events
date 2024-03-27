using Events.Domain.ValueObjects;

namespace Events.Application.DTOs
{
    public record MemberDTO(string Description, MemberType Type);
}
