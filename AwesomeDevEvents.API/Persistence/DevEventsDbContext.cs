using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence;

public class DevEventsDbContext : DbContext
{
    public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
    {

    }

    public DbSet<DevEvent> DevEvents { get; set; }
    public DbSet<DevEventSpeaker> DevEventsSpeakers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<DevEvent>(e =>
        {
            e.HasKey(devEvent => devEvent.Id);
            e.Property(devEvent => devEvent.Title)
                .IsRequired(false);
            e.Property(devEvent => devEvent.Description)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");
            e.Property(devEvent => devEvent.StartDate)
                .HasColumnName("Start_Date");
            e.Property(devEvent => devEvent.EndDate)
                .HasColumnName("End_Date");
            e.HasMany(devEvent => devEvent.Speakers)
                .WithOne()
                .HasForeignKey(devEvent => devEvent.DevEventId);
        });

        builder.Entity<DevEventSpeaker>(e =>
        {
            e.HasKey(devEventSpeakeres => devEventSpeakeres.Id);
        });
    }
}
