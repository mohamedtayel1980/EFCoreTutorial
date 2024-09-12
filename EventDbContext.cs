using EventManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Date)
                      .HasColumnType("date");
            });
            modelBuilder.Entity<Event>()
       .HasOne(e => e.EventDetail)
       .WithOne(ed => ed.Event)
       .HasForeignKey<EventDetail>(ed => ed.EventId);
            modelBuilder.Entity<Event>()
        .HasOne(e => e.Category)
        .WithMany(c => c.Events)
        .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Event>()
      .HasMany(e => e.Attendees)
      .WithMany(a => a.Events)
      .UsingEntity<Dictionary<string, object>>(
          "EventAttendees",  // The name of the join table
          j => j.HasOne<Attendee>()
                .WithMany()
                .HasForeignKey("AttendeeId")  // Specify the column name for the foreign key to Attendees
                .OnDelete(DeleteBehavior.Cascade),
          j => j.HasOne<Event>()
                .WithMany()
                .HasForeignKey("EventId")  // Specify the column name for the foreign key to Events
                .OnDelete(DeleteBehavior.Cascade),
          j =>
          {
              j.Property<DateTime>("JoinedOn").HasDefaultValueSql("GETDATE()");
              j.ToTable("EventAttendees");  
          }
      );

            modelBuilder.Entity<Event>()
        .Property<DateTime>("CreatedDate");

            modelBuilder.Entity<Event>()
       .Property(e => e.Price)
       .HasField("_price");
            base.OnModelCreating(modelBuilder);
        }
    }
}
