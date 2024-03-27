using Events.Domain.Entities;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.Repositories
{
    /// <summary>
    /// Provides an interface for repository operations related to the <see cref="Member"/> entity.
    /// </summary>
    public interface IMemberRepository
    {
        /// <summary>
        /// Retrieves a paginated list of members.
        /// </summary>
        /// <param name="aPageSize">The number of members to retrieve per page.</param>
        /// <param name="aPage">The page number to retrieve. Default is 1.</param>
        /// <returns>The list of members matching the filters or Error.</returns>
        public Task<IHttpResult<IEnumerable<Member>>> GetMembersListAsync(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default);

        /// <summary>
        /// Adds a new member to the repository.
        /// </summary>
        /// <param name="aNewMember">The member to add.</param>
        /// <returns>The added member.</returns>
        Task<IHttpResult<Member>> Add(Member aNewMember, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Deletes a specified member from the repository.
        /// </summary>
        /// <param name="aMemberToDelete">The member to delete.</param>
        /// <returns>The deleted member or Error</returns>
        Task<IHttpResult<Member>> Delete(Member aMemberToDelete, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Updates a specified member in the repository.
        /// </summary>
        /// <param name="aMember">The member to update.</param>
        /// <returns>The updated member or Error.</returns>
        Task<IHttpResult<Member>> Update(Member aMember, CancellationToken aCancellationToken = default);

        /// <summary>
        /// Get the number of registered guild members.
        /// </summary>
        /// <returns>Returns the number registered guild members or Error.</returns>
        Task<IHttpResult<int>> GetCountAsync(CancellationToken aCancellationToken = default);

    }
}
