using Events.Domain.Contracts.Repositories;
using Events.Domain.Entities;
using Events.Infrastructure.DataAccess.DbContexts;
using Microsoft.Extensions.Logging;
using TGF.CA.Infrastructure.DB.Repository;
using TGF.CA.Infrastructure.DB.Repository.CQRS.EntityRepository;

namespace Events.Infrastructure.Repositories
{
    public class TagRepository(EventsDbContext aContext, ILogger<EventRepository> aLogger)
        : EntityRepository<EventRepository, EventsDbContext, Tag, Guid>(aContext, aLogger), ITagRepository, ISortRepository
    {

    }
}
