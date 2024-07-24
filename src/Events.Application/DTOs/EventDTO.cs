
namespace Events.Application.DTOs
{
    public record EventDTO(
        Guid Id,
        string Name,
        string? Description,
        TimeSpan ExpectedDuration,
        DateTimeOffset StartDate,
        DateTimeOffset LaunchDate,
        DateTimeOffset EndDate);
}
