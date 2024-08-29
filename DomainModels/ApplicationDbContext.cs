using Microsoft.EntityFrameworkCore;

namespace DomainModels
{
    public class ApplicationDbContext : DbContext  // Fix here: Corrected the syntax
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
                .ToTable("profile")  // Ensure the table name matches the schema
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
