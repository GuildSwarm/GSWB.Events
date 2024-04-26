using Events.Domain.Contracts.Repositories;
using Events.Domain.Entities;
using Events.Infrastructure.DataAccess.DbContexts;
using Microsoft.Extensions.Logging;
using TGF.CA.Infrastructure.DB.Repository;
using TGF.Common.ROP.HttpResult;

namespace Events.Infrastructure.Repositories
{
    public class TagRepository(EventsDbContext aContext, ILogger<EventRespository> aLogger)
        : RepositoryBase<EventRespository, EventsDbContext>(aContext, aLogger), ITagRepository, ISortRepository
    {

    }
}
