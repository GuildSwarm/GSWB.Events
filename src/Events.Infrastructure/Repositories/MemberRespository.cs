//using Events.Application.Contracts.Repositories;
using Events.Domain.Entities;
using Events.Infrastructure.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TGF.CA.Infrastructure.DB.Repository;
using TGF.Common.ROP.HttpResult;

namespace Events.Infrastructure.Repositories
{
    //public class MemberRepository(MembersDbContext aContext, ILogger<MemberRepository> aLogger)
    //    : RepositoryBase<MemberRepository, MembersDbContext>(aContext, aLogger), IMemberRepository, ISortRepository
    //{

    //    public async Task<IHttpResult<IEnumerable<Member>>> GetMembersListAsync(
    //        int aPage, int aPageSize,
    //        string aSortBy,
    //        CancellationToken aCancellationToken = default)
    //    => await TryQueryAsync(async (aCancellationToken) =>
    //    {
    //        var lQuery = _context.Members
    //        .AsQueryable();

    //        lQuery = ISortRepository.ApplySorting(lQuery, aSortBy);

    //        return await lQuery
    //            .Skip((aPage - 1) * aPageSize)
    //            .Take(aPageSize)
    //            .ToListAsync(aCancellationToken) as IEnumerable<Member>;

    //    }, aCancellationToken);


    //    public async Task<IHttpResult<Member>> Add(Member aNewMember, CancellationToken aCancellationToken = default)
    //        => await TryCommandAsync(() => _context.Members.Add(aNewMember).Entity, aCancellationToken);

    //    public async Task<IHttpResult<Member>> Update(Member aMember, CancellationToken aCancellationToken = default)
    //        => await TryCommandAsync(() => _context.Members.Update(aMember).Entity, aCancellationToken);

    //    public async Task<IHttpResult<Member>> Delete(Member aMemberToDelete, CancellationToken aCancellationToken = default)
    //        => await TryCommandAsync(() => _context.Members.Remove(aMemberToDelete).Entity, aCancellationToken);

    //    public async Task<IHttpResult<int>> GetCountAsync(CancellationToken aCancellationToken = default)
    //    => await TryQueryAsync(async (aCancellationToken)
    //        => await _context.Members.CountAsync(aCancellationToken)
    //    , aCancellationToken);

    //}
}
