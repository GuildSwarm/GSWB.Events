using Microsoft.EntityFrameworkCore;
using Events.Domain.Entities;
using TGF.CA.Infrastructure.DB.DbContext;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Events.Infrastructure.DataAccess.DbContexts
{
    public class EventsDbContext(DbContextOptions<EventsDbContext> aOptions) : EntitiesDbContext<EventsDbContext>(aOptions)
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
        public virtual DbSet<EventParticipationRequirement> EventParticipationRequirements { get; set; }
        public virtual DbSet<ParticipationRequirement> ParticipationRequirements { get; set; }
        public virtual DbSet<EventRole> EventRoles { get; set; }
        public virtual DbSet<EventRoleTemplate> EventRoleTemplates { get; set; }
        public virtual DbSet<Tag> EventTags { get; set; }
        public virtual DbSet<EventTemplate> EventTemplates { get; set; }
        public virtual DbSet<StaticTransaction> StaticTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the ValueConverter to convert ulong to decimal and back
            var ulongToDecimalConverter = new ValueConverter<ulong, decimal>(
                v => Convert.ToDecimal(v),    // Convert ulong to decimal for storage
                v => Convert.ToUInt64(v)      // Convert decimal back to ulong
            );

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.StartDate).IsRequired();

                entity.HasMany(e => e.Managers)
                      .WithOne(m => m.Event)
                      .HasForeignKey(m => m.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Tags)
                      .WithOne(t => t.Event)
                      .HasForeignKey(t => t.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Requirements)
                      .WithOne(epr => epr.Event)
                      .HasForeignKey(epr => epr.Id)
                      .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<EventManager>(entity =>
            {
                entity.HasKey(em => em.Id);

                // Configure MemberKey as an owned type, mapping its properties to columns in the table
                entity.OwnsOne(e => e.MemberId, key =>
                {
                    key.Property(k => k.GuildId)
                        .HasColumnType("numeric(20,0)")
                        .HasConversion(ulongToDecimalConverter);  // Convert ulong to decimal

                    key.Property(k => k.UserId)
                        .HasColumnType("numeric(20,0)")
                        .HasConversion(ulongToDecimalConverter);  // Convert ulong to decimal
                });

                entity.Property(em => em.Logbook).HasMaxLength(1000);
            });

            modelBuilder.Entity<EventTag>(entity =>
            {
                entity.HasKey(et => et.Id);
                entity.Property(et => et.TagId).IsRequired();
            });

            modelBuilder.Entity<ActivityParticipation>(entity =>
            {
                entity.HasKey(em => em.Id);

                // Configure MemberKey as an owned type, mapping its properties to columns in the table
                entity.OwnsOne(e => e.MemberId, key =>
                {
                    key.Property(k => k.GuildId)
                        .HasColumnType("numeric(20,0)")
                        .HasConversion(ulongToDecimalConverter);  // Convert ulong to decimal

                    key.Property(k => k.UserId)
                        .HasColumnType("numeric(20,0)")
                        .HasConversion(ulongToDecimalConverter);  // Convert ulong to decimal
                });
            });

            modelBuilder.Entity<EventParticipation>(entity =>
            {
                entity.HasKey(em => em.Id);

                // Configure MemberKey as an owned type, mapping its properties to columns in the table
                entity.OwnsOne(e => e.MemberId, key =>
                {
                    key.Property(k => k.GuildId)
                        .HasColumnType("numeric(20,0)")
                        .HasConversion(ulongToDecimalConverter);  // Convert ulong to decimal

                    key.Property(k => k.UserId)
                        .HasColumnType("numeric(20,0)")
                        .HasConversion(ulongToDecimalConverter);  // Convert ulong to decimal
                });
            });

            modelBuilder.Entity<EventParticipationRequirement>(entity =>
            {
                entity.HasKey(et => et.Id);
                entity.Property(et => et.ParticipationRequirementId).IsRequired();
            });
        }

    }
}
