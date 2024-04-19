using Common.Application.DTOs.Events;
using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.UseCases;
using Events.Application.Contracts.UseCases.EventManagers;
using Events.Application.DTOs;
using Events.Application.Mappings;
using Events.Domain.Entities;
using Events.Domain.Validation;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases.EventManagers
{
    public class DeleteEventManagersService(
        IEventRepository aEventRepository)
    : IDeleteEventManagersService
    {
        public async Task<IHttpResult<EventDTO>> DeleteManagers(EventManagersDTO aEventManagersDTO, CancellationToken aCancellationToken = default)
        {
            var lEventResult = await Result.CancellationTokenResult(aCancellationToken)
                .Bind(_ => aEventRepository.GetByIdAsync<Event, Guid>(aEventManagersDTO.EventId));

            return lEventResult.Bind(anEvent => anEvent.DeleteManagers(aEventManagersDTO.MemberIdList))
                .Bind(_ => lEventResult)
                .Map(anEvent => anEvent.ToDto());
        }
    }
}
