using Common.Application.DTOs.Events;
using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.UseCases.EventManagers;
using Events.Application.DTOs;
using Events.Application.Mappings;
using Events.Domain.Entities;
using Events.Domain.Validation;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases.EventManagers
{
    public class AddEventManagersService(
        IEventRepository aEventRepository,
        EventManagerValidator aEventManagerValidator)
    : IAddEventManagersService
    {
        public async Task<IHttpResult<EventDTO>> AddManagers(EventManagersDTO aAddEventManagersDTO, CancellationToken aCancellationToken = default)
        {
            var lEventResult = await Result.CancellationTokenResult(aCancellationToken)
                .Bind(_ => aEventRepository.GetByIdAsync<Event, Guid>(aAddEventManagersDTO.EventId));

            return lEventResult.Bind(anEvent => anEvent.AddManagers(aAddEventManagersDTO.MemberIdList, aEventManagerValidator))
                .Bind(_ => lEventResult)
                .Map(anEvent => anEvent.ToDto());
        }
    }
}
