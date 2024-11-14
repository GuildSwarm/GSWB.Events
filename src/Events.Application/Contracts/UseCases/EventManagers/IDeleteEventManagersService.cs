using Common.Application.DTOs.Events;
using Common.Domain.ValueObjects;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.EventManagers
{
    public interface IDeleteEventManagersService
    {
        Task<IHttpResult<IEnumerable<EventManagerDetailDTO>>> DeleteManagers(Guid aEventId, string aAccessToken, IEnumerable<MemberKey> aMemberKeyList, CancellationToken aCancellationToken = default);
    }
}