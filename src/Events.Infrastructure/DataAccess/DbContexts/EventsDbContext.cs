using Microsoft.EntityFrameworkCore;
using Events.Domain.Entities;

namespace Events.Infrastructure.DataAccess.DbContexts
{
    public class EventsDbContext(DbContextOptions<EventsDbContext> aOptions) : DbContext(aOptions)
    {
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityParticipation> ActivityParticipations { get; set; }
        public virtual DbSet<ActivityTemplate> ActivityTemplates { get; set; }
        public virtual DbSet<DiscordEventChannel> DiscordEventChannels { get; set; }
        public virtual DbSet<DiscordEventChannelTemplate> DiscordEventChannelTemplate { get; set; }
        public virtual DbSet<DynamicTransaction> DynamicTransactions { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventActivity> EventActivities { get; set; }
        public virtual DbSet<EventManager> EventManagemers { get; set; }
        public virtual DbSet<EventParticipation> EventParticipations { get; set; }
        public virtual DbSet<EventRequirement> EventRequirements { get; set; }
        public virtual DbSet<EventRole> EventRoles { get; set; }
        public virtual DbSet<EventRoleTemplate> EventRoleTemplates { get; set; }
        public virtual DbSet<EventTag> EventTags { get; set; }
        public virtual DbSet<EventTemplate> EventTemplates { get; set; }
        public virtual DbSet<StaticTransaction> StaticTransactions { get; set; }

    }
}
