using HotelWebsite.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HotelWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }

        // ... other DbSet properties ...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profile>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}