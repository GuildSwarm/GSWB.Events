using Common.Application.DTOs.Events;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.EventManagers
{
    public interface IAddEventManagersService
    {
        Task<IHttpResult<IEnumerable<EventManagerDetailDTO>>> AddManagers(EventManagersDTO aAddEventManagersDTO, string aAccessToken, CancellationToken aCancellationToken = default);
    }
}