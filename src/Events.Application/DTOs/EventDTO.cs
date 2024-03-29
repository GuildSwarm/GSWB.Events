
namespace Events.Application.DTOs
{
    public record EventDTO(
        string Name,
        string? Description,
        TimeSpan ExpectedDuration,
        DateTime StartDate,
        DateTime LaunchDate,
        DateTime EndDate);
}
