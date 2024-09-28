using Common.Application.Contracts.Services;
using Common.Application.DTOs.Events;
using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.UseCases.EventManagers;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases.EventManagers
{
    public class DeleteEventManagersService(
        IEventRepository aEventRepository,
        IMembersCommunicationService aMembersCommunicationService)
    : IDeleteEventManagersService
    {
        public async Task<IHttpResult<IEnumerable<EventManagerDetailDTO>>> DeleteManagers(Guid aEventId, string aAccessToken, IEnumerable<Guid> aMemberIdList, CancellationToken aCancellationToken = default)
        {
            var lEventResult = await Result.CancellationTokenResult(aCancellationToken)
                .Bind(_ => aEventRepository.GetWithManagersAsync(aEventId));

            var lAfterDeleteManagersResult = await lEventResult.Bind(anEvent => anEvent.DeleteManagers(aMemberIdList))
                .Bind(_ => aEventRepository.UpdateAsync(lEventResult.Value))
                .Map(anEvent => anEvent.Managers);

            return await lAfterDeleteManagersResult.Map(managerList => managerList.Select(manager => manager.MemberId))
                .Bind(managerIdList => aMembersCommunicationService.GetMembersByIdList(managerIdList, aAccessToken, aCancellationToken))
                .Map(memberList => memberList
                    .Select(member => new EventManagerDetailDTO(member, lAfterDeleteManagersResult.Value
                        .FirstOrDefault(manager => manager.MemberId == member.Id)?.Logbook))
                );

        }
    }
}
