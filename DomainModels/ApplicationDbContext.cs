using Microsoft.EntityFrameworkCore;

namespace DomainModels
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }

        // ... other DbSet properties ...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Profile>()
                .ToTable("profile")  
                .HasIndex(p => p.Email)
                .IsUnique();

            // Configure Room table
            modelBuilder.Entity<Room>()
                .ToTable("room")  // Map to 'room' table in the database
                .Property(r => r.Photos);

            modelBuilder.Entity<Booking>()
                .ToTable("booking")  // Map to 'booking' table in the database
                .HasOne(b => b.Profile)    // Each Booking has one Profile
                .WithMany(p => p.Bookings) // Each Profile can have many Bookings
                .HasForeignKey(b => b.ProfileId) // Foreign key in Booking to Profile
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Profile is deleted

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)       // Each Booking has one Room
                .WithMany(r => r.Bookings) // Each Room can have many Bookings
                .HasForeignKey(b => b.RoomId)  // Foreign key in Booking to Room
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Room is deleted

            modelBuilder.Entity<SupportRequest>()
                .ToTable("support_request")  // Map to the 'support_request' table
                .Property(sr => sr.Status)
                .HasDefaultValue("Pending");  // Default value for status is "Pending"


            // Automatically set CreatedAt and UpdatedAt timestamps
            modelBuilder.Entity<Common>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");  // SQL Server example, adjust for your DBMS

            modelBuilder.Entity<Common>()
                .Property(c => c.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            // Configure timestamps for each entity that inherits from Common
            modelBuilder.Entity<Profile>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Profile>()
                .Property(p => p.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Room>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Room>()
                .Property(r => r.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Booking>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Booking>()
                .Property(b => b.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<SupportRequest>()
                .Property(sr => sr.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<SupportRequest>()
                .Property(sr => sr.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
