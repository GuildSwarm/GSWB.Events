using Common.Application.DTOs.Events;
using Events.Application.DTOs;
using TGF.CA.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.Services
{
    public interface IEventsService
    {
        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="aCreateEventDto"></param>
        /// <param name="aCancellationToken"></param>
        /// <returns><see cref="EventDTO"/> with information from the event after being created.</returns>
        public Task<IHttpResult<EventDTO>> CreateEvent(CreateEventDTO aCreateEventDto, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Get a page with a list of Events based on listing criterea such as apgination and filtering.
        /// </summary>
        /// <param name="aPage"></param>
        /// <param name="aPageSize"></param>
        /// <param name="aSortBy"></param>
        /// <param name="aCancellationToken"></param>
        /// <returns></returns>
        public Task<IHttpResult<PaginatedListDTO<EventDTO>>> GetEventList(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default);
    }
}
