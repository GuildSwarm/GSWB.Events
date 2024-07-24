using Common.Application.Contracts.Services;
using Common.Application.DTOs.Events;
using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.UseCases.EventManagers;
using Events.Domain.Entities;
using Events.Domain.Validation;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases.EventManagers
{
    public class AddEventManagersService(
        IEventRepository aEventRepository,
        IMembersCommunicationService aMembersCommunicationService,
        EventManagerValidator aEventManagerValidator)
    : IAddEventManagersService
    {
        public async Task<IHttpResult<IEnumerable<EventManagerDetailDTO>>> AddManagers(EventManagersDTO aAddEventManagersDTO, string aAccessToken, CancellationToken aCancellationToken = default)
        {
            var lEventResult = await Result.CancellationTokenResult(aCancellationToken)
                .Bind(_ => aEventRepository.GetByIdAsync(aAddEventManagersDTO.EventId));

            var lManagerList = await lEventResult.Bind(anEvent => anEvent.AddManagersAsync(aAddEventManagersDTO.MemberIdList, aEventManagerValidator))
                .Bind(_ => aEventRepository.UpdateAsync(lEventResult.Value))
                .Map(anEvent => anEvent.Managers);

            return await lManagerList.Map(managers => managers.Select(manager => manager.MemberId))
                .Bind(managerIdList => aMembersCommunicationService.GetMembersByIdList(managerIdList, aAccessToken, aCancellationToken))
                .Map(memberList => memberList
                    .Select(member => new EventManagerDetailDTO(member, lManagerList.Value
                        .FirstOrDefault(manager => manager.MemberId == member.Id)?.Logbook))
                );
        }
    }
}
