using Common.Application.Contracts.Services;
using Common.Application.DTOs.Events;
using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.UseCases.EventManagers;
using Events.Domain.Entities;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases.EventManagers
{
    public class ListEventManagers(
        IEventRepository aEventRepository,
        IMembersCommunicationService aMembersCommunicationService)
    : IListEventManagersService
    {
        public async Task<IHttpResult<IEnumerable<EventManagerDetailDTO>>> ListManagers(Guid aEventId, string aAccessToken, CancellationToken aCancellationToken = default)
        {
            var lManagerList = await Result.CancellationTokenResult(aCancellationToken)
                .Bind(_ => aEventRepository.GetWithManagersAsync(aEventId))
                .Map(anEvent => anEvent.Managers);

            return await lManagerList
                .Map(managers => managers.Select(manager => manager.MemberId))
                .Bind(managerIdList => aMembersCommunicationService.GetMembersByIdList(managerIdList, aAccessToken, aCancellationToken))
                .Map(memberList => memberList
                    .Select(member => new EventManagerDetailDTO(member, lManagerList.Value
                        .FirstOrDefault(manager => manager.MemberId == member.Id)?.Logbook))
                );
        }
    }
}
