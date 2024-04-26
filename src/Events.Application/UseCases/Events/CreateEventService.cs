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
    public class CreateEventService(IEventRepository aEventRepository, TagIdListValidator aTagIdListValidator, EventManagerValidator aEventManagerValidator)
        : ICreateEventService
    {
        public async Task<IHttpResult<EventDTO>> CreateEvent(CreateEventDTO aCreateEventDTO, CancellationToken aCancellationToken = default)
        {
            var lEventResult = await Result.CancellationTokenResult(aCancellationToken)
                .Map(_ => GetNewEventFromEventInformation(aCreateEventDTO.EventInformation))
                //.Tap(newEvent => newEvent.AddManagers([aCreateEventDTO.MemberIdCreator], aEventManagerValidator))
                .Bind(newEvent => aEventRepository.AddAsync(newEvent))//Removed MemberIdCreator from DTO, get the actor member Id from the access token DiscordId using members endpoint MembersApiRoutes.private_members_getByDiscordUserId
                .Map(newEvent => newEvent.ToDto());

            return lEventResult;
        }

        private Event GetNewEventFromEventInformation(EventInformationDTO aEventInformationDTO)
        {
            var lNewEvent = new Event() {
                Name = aEventInformationDTO.Name,
                Description = aEventInformationDTO.Description,
                StartDate = aEventInformationDTO.StartDate,
                ExpectedDuration = aEventInformationDTO.ExpectedDuration,
            };
            _ = lNewEvent.AddTags(aEventInformationDTO.TagIdList, aTagIdListValidator);
            return lNewEvent;
        }
    }
}
