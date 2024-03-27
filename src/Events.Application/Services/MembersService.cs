using Events.Application.Contracts.Repositories;
using Events.Application.Contracts.Services;
using Events.Application.DTOs;
using Events.Application.Mappings;
using Events.Domain.Entities;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Services
{
    public class MembersService : IMembersService
    {
        private readonly IMemberRepository _memberRepository;
        public MembersService(
            IMemberRepository aMemberRepository)
        {
            _memberRepository = aMemberRepository;
        }

        #region IMemberService
        public async Task<IHttpResult<PaginatedMemberListDTO>> GetMemberList(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default)
        => await _memberRepository.GetMembersListAsync(aPage, aPageSize, aSortBy, aCancellationToken)
            .Bind(memberList => GetPaginatedMemberListDTO(memberList, aPage, aPageSize));


        #endregion

        #region Private 
        private async Task<IHttpResult<PaginatedMemberListDTO>> GetPaginatedMemberListDTO(IEnumerable<Member> aMemberList, int aCurrentPage, int aPageSize)
        => await _memberRepository.GetCountAsync()
            .Map(memberCount => new PaginatedMemberListDTO(aCurrentPage, (int)Math.Ceiling((double)memberCount / aPageSize), aPageSize, memberCount, aMemberList.Select(member => member.ToDto()).ToArray()));
        #endregion
    }
}
