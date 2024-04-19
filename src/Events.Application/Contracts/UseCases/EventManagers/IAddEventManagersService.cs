using Common.Application.DTOs.Events;
using Events.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.EventManagers
{
    public interface IAddEventManagersService
    {
        Task<IHttpResult<EventDTO>> AddManagers(EventManagersDTO aAddEventManagersDTO, CancellationToken aCancellationToken = default);
    }
}