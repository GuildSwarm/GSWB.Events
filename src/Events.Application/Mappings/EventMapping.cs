using Events.Application.DTOs;
using Events.Domain.Entities;
using Common.Domain.ValueObjects;
using System.Data;


namespace Events.Application.Mappings
{
    public static class EventMapping
    {
        public static EventDTO ToDto(this Event aEvent)
        => new(aEvent.Id, aEvent.Name, aEvent.Description, aEvent.ExpectedDuration, aEvent.StartDate, aEvent.LaunchDate, aEvent.EndDate);
    }
}
