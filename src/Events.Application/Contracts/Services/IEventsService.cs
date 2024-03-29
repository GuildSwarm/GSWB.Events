using Events.Application.DTOs;
using TGF.CA.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.Services
{
    public interface IEventsService
    {
        public Task<IHttpResult<PaginatedListDTO<EventDTO>>> GetEventList(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default);
    }
}
