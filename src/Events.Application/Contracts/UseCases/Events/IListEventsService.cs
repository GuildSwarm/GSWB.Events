using Events.Application.DTOs;
using TGF.CA.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.Events
{
    public interface IListEventsService
    {
        /// <summary>
        /// Get a page with a list of Events based on listing criterea such as apgination and filtering.
        /// </summary>
        /// <param name="aPage"></param>
        /// <param name="aPageSize"></param>
        /// <param name="aSortBy"></param>
        /// <param name="aCancellationToken"></param>
        /// <returns></returns>
        public Task<IHttpResult<PagedListDTO<EventDTO>>> ListEvents(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default);
    }
}
