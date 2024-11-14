using Common.Application.DTOs.Events;
using Common.Domain.ValueObjects;
using Events.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.Events
{
    public interface ICreateEventService
    {
        Task<IHttpResult<EventDTO>> CreateEvent(MemberKey aMembeKeyCreator, CreateEventDTO aCreateEventDTO, CancellationToken aCancellationToken = default);

    }
}
