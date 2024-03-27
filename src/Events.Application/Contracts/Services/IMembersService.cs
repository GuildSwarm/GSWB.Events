using Events.Application.DTOs;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.Services
{
    public interface IMembersService
    {
        public Task<IHttpResult<PaginatedMemberListDTO>> GetMemberList(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default);
    }
}
