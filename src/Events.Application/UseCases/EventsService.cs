using Common.Application.DTOs.Events;
using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.Services;
using Events.Application.DTOs;
using Events.Application.Mappings;
using Events.Domain.Entities;
using TGF.CA.Application.DTOs;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases
{
    public class EventsService(
        IEventRepository aEventRepository) : IEventsService
    {

        #region IEventService
        public async Task<IHttpResult<EventDTO>> CreateEvent(CreateEventDTO aCreateEventDto, CancellationToken aCancellationToken = default)
            => await Result.CancellationTokenResult(aCancellationToken)
            .Bind(_ => aEventRepository.AddAsync(new Event() { Name = "Test" }, aCancellationToken))
            .Map(newEvent => newEvent.ToDto());

        public async Task<IHttpResult<PaginatedListDTO<EventDTO>>> GetEventList(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default)
        => await Result.CancellationTokenResult(aCancellationToken)
            .Bind(_ => aEventRepository.GetEventListAsync(aPage, aPageSize, aSortBy, aCancellationToken))
            .Bind(EventList => GetPaginatedEventListDTO(EventList, aPage, aPageSize));


        #endregion

        #region Private 
        private async Task<IHttpResult<PaginatedListDTO<EventDTO>>> GetPaginatedEventListDTO(IEnumerable<Event> aEventList, int aCurrentPage, int aPageSize)
        => await aEventRepository.GetCountAsync()
            .Map(EventCount => new PaginatedListDTO<EventDTO>(aCurrentPage, (int)Math.Ceiling((double)EventCount / aPageSize), aPageSize, EventCount, aEventList.Select(Event => Event.ToDto()).ToArray()));
        #endregion
    }
}
