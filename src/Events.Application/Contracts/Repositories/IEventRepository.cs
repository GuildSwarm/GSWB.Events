using Events.Domain.Entities;
using TGF.CA.Application.Contracts.Repositories;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.Repositories
{
    /// <summary>
    /// Provides an interface for repository operations related to the<see cref="Event"/> entity.
    /// </summary>
    public interface IEventRepository : IRepositoryBase
    {
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
        /// Adds a new event to the repository.
        /// </summary>
        /// <param name="aNewEvent">The event to add.</param>
        /// <returns>The added event.</returns>
        Task<IHttpResult<Event>> Add(Event aNewEvent, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Deletes a specified event from the repository.
        /// </summary>
        /// <param name="aEventToDelete">The event to delete.</param>
        /// <returns>The deleted event or Error</returns>
        Task<IHttpResult<Event>> Delete(Event aEventToDelete, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Updates a specified event in the repository.
        /// </summary>
        /// <param name="aEvent">The event to update.</param>
        /// <returns>The updated event or Error.</returns>
        Task<IHttpResult<Event>> Update(Event aEvent, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Get the number of registered events.
        /// </summary>
        /// <returns>Returns the number registered guild events or Error.</returns>
        Task<IHttpResult<int>> GetCountAsync(CancellationToken aCancellationToken = default);

    }
}
