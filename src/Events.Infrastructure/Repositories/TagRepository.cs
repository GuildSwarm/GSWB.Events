using Events.Domain.Contracts.Repositories;
using Events.Domain.Entities;
using Events.Infrastructure.DataAccess.DbContexts;
using Microsoft.Extensions.Logging;
using TGF.CA.Infrastructure.DB.Repository;

namespace Events.Infrastructure.Repositories
{
    public class TagRepository(EventsDbContext aContext, ILogger<EventRespository> aLogger)
        : RepositoryBase<EventRespository, EventsDbContext, Tag, Guid>(aContext, aLogger), ITagRepository, ISortRepository
    {

    }
}
