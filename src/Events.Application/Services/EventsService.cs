using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.Services;
using Events.Application.DTOs;
using Events.Application.Mappings;
using Events.Domain.Entities;
using TGF.CA.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Services
{
    public class EventsService(
        IEventRepository aEventRepository) : IEventsService
    {
        private readonly IEventRepository _eventRepository = aEventRepository;

        #region IEventService
        public async Task<IHttpResult<PaginatedListDTO<EventDTO>>> GetEventList(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default)
        => await _eventRepository.GetEventListAsync(aPage, aPageSize, aSortBy, aCancellationToken)
            .Bind(EventList => GetPaginatedEventListDTO(EventList, aPage, aPageSize));


        #endregion

        #region Private 
        private async Task<IHttpResult<PaginatedListDTO<EventDTO>>> GetPaginatedEventListDTO(IEnumerable<Event> aEventList, int aCurrentPage, int aPageSize)
        => await _eventRepository.GetCountAsync()
            .Map(EventCount => new PaginatedListDTO<EventDTO>(aCurrentPage, (int)Math.Ceiling((double)EventCount / aPageSize), aPageSize, EventCount, aEventList.Select(Event => Event.ToDto()).ToArray()));
        #endregion
    }
}
