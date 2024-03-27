using Microsoft.EntityFrameworkCore;
using Events.Domain.Entities;

namespace Events.Infrastructure.DataAccess.DbContexts
{
    public class EventsDbContext(DbContextOptions<EventsDbContext> aOptions) : DbContext(aOptions)
    {
        //public virtual DbSet<Member> Members { get; set; }
    }
}
