using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.UseCases.Events;
using Events.Application.DTOs;
using Events.Application.Mappings;
using Events.Domain.Entities;
using TGF.CA.Application.DTOs;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Application.UseCases.Events
{
    public class ListEventsService(
        IEventRepository aEventRepository) : IListEventsService
    {

        #region IEventService

        public async Task<IHttpResult<PaginatedListDTO<EventDTO>>> ListEvents(
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
