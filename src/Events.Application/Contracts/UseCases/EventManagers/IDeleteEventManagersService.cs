using Common.Application.DTOs.Events;
using Events.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases
{
    public interface IDeleteEventManagersService
    {
        Task<IHttpResult<EventDTO>> DeleteManagers(EventManagersDTO aAddEventManagersDTO, CancellationToken aCancellationToken = default);
    }
}