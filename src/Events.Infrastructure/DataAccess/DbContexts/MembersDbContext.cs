using Microsoft.EntityFrameworkCore;
using Events.Domain.Entities;

namespace Events.Infrastructure.DataAccess.DbContexts
{
    public class MembersDbContext(DbContextOptions<MembersDbContext> aOptions) : DbContext(aOptions)
    {
        public virtual DbSet<Member> Members { get; set; }
    }
}
