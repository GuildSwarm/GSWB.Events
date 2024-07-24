using Common.Application.DTOs.Events;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.EventManagers
{
    public interface IListEventManagersService
    {
        Task<IHttpResult<IEnumerable<EventManagerDetailDTO>>> ListManagers(Guid aEventId, string aAccessToken, CancellationToken aCancellationToken = default);
    }
}