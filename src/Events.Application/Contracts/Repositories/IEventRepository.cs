using Events.Domain.Entities;
using TGF.CA.Domain.Contracts.Repositories;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.Repositories
{
    /// <summary>
    /// Provides an interface for repository operations related to the<see cref="Event"/> entity.
    /// </summary>
    public interface IEventRepository : IRepositoryBase
    {
        /// <summary>
        /// Get a given event from its id including the managers
        /// </summary>
        /// <param name="aId"></param>
        /// <param name="aCancellationToken"></param>
        /// <returns></returns>
        public Task<IHttpResult<Event>> GetByIdAsync(Guid aId, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of Events.
        /// </summary>
        /// <param name="aPageSize">The number of events to retrieve per page.</param>
        /// <param name="aPage">The page number to retrieve. Default is 1.</param>
        /// <returns>The list of events matching the filters or Error.</returns>
        public Task<IHttpResult<IEnumerable<Event>>> GetEventListAsync(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default);

        /// <summary>
        /// Get the number of registered events.
        /// </summary>
        /// <returns>Returns the number registered guild events or Error.</returns>
        Task<IHttpResult<int>> GetCountAsync(CancellationToken aCancellationToken = default);

    }
}
