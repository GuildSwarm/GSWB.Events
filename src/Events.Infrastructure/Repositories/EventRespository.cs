using Events.Application.Contracts.Repositories;
using Events.Domain.Entities;
using Events.Infrastructure.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TGF.CA.Infrastructure.DB.Repository;
using TGF.Common.ROP.HttpResult;

namespace Events.Infrastructure.Repositories
{
    public class EventRespository(EventsDbContext aContext, ILogger<EventRespository> aLogger)
        : RepositoryBase<EventRespository, EventsDbContext, Event, Guid>(aContext, aLogger), IEventRepository, ISortRepository
    {
        public async Task<IHttpResult<IEnumerable<Event>>> GetEventListAsync(
            int aPage, int aPageSize,
            string aSortBy,
            CancellationToken aCancellationToken = default)
        => await TryQueryAsync(async (aCancellationToken) =>
        {
            var lQuery = _context.Events
            .Include(e => e.Managers).AsQueryable();

            lQuery = ISortRepository.ApplySorting(lQuery, aSortBy);

            return await lQuery
                .Skip((aPage - 1) * aPageSize)
                .Take(aPageSize)
                .ToListAsync(aCancellationToken) as IEnumerable<Event>;

        }, aCancellationToken);

        public async Task<IHttpResult<Event>> GetWithManagersAsync(Guid eventId, CancellationToken aCancellationToken = default)
        => await TryQueryAsync(async (aCancellationToken) =>
        {
            return await _context.Events
            .Include(e => e.Managers)
            .FirstAsync(anEvent => anEvent.Id == eventId);

        }, aCancellationToken);

        public async Task<IHttpResult<int>> GetCountAsync(CancellationToken aCancellationToken = default)
        => await TryQueryAsync(async (aCancellationToken)
            => await _context.Events.CountAsync(aCancellationToken)
        , aCancellationToken);

    }
}
