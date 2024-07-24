using Common.Application.Contracts.Services;
using Common.Application.DTOs.Events;
using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.UseCases.Events;
using Events.Application.DTOs;
using Events.Application.Mappings;
using Events.Domain.Entities;
using Events.Domain.Validation;
using Events.Domain.Validation.Tag;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases.Events
{
    public class CreateEventService(IEventRepository aEventRepository, IMembersCommunicationService aMembersCommunicationService, TagIdListValidator aTagIdListValidator, EventManagerValidator aEventManagerValidator)
        : ICreateEventService
    {
        public async Task<IHttpResult<EventDTO>> CreateEvent(string aDiscordMembeIdCreator, CreateEventDTO aCreateEventDTO, CancellationToken aCancellationToken = default)
        {
            var lMemberCreatorResult = await Result.CancellationTokenResult(aCancellationToken)
                .Bind( _ => aMembersCommunicationService.GetExistingMember(Convert.ToUInt64(aDiscordMembeIdCreator), aCancellationToken));

            var lNewEventResult = await lMemberCreatorResult
                .Map(_ => GetNewEventFromEventInformation(aCreateEventDTO.EventInformation));

            var lCreateEventResult = await lNewEventResult
                .Bind(newEvent => newEvent.AddManagersAsync([lMemberCreatorResult.Value.Id], aEventManagerValidator))
                .Bind(_ => aEventRepository.AddAsync(lNewEventResult.Value))
                .Map(newEvent => newEvent.ToDto());

            return lCreateEventResult;
        }

        private async Task<Event> GetNewEventFromEventInformation(EventInformationDTO aEventInformationDTO)
        {
            var lNewEvent = new Event() {
                Name = aEventInformationDTO.Name,
                Description = aEventInformationDTO.Description,
                StartDate = aEventInformationDTO.StartDate,
                ExpectedDuration = TimeSpan.FromMinutes(aEventInformationDTO.ExpectedDurationInMinustes),
            };
            _ = await lNewEvent.AddTagsAsync(aEventInformationDTO.TagIdList, aTagIdListValidator);
            return lNewEvent;
        }
    }
}
