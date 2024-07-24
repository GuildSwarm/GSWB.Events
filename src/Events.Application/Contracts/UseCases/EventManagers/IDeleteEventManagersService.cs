using Common.Application.DTOs.Events;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.EventManagers
{
    public interface IDeleteEventManagersService
    {
        Task<IHttpResult<IEnumerable<EventManagerDetailDTO>>> DeleteManagers(Guid aEventId, string aAccessToken, IEnumerable<Guid> aMemberIdList, CancellationToken aCancellationToken = default);
    }
}