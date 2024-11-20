using Microsoft.EntityFrameworkCore;
using FancySignup.Models;

namespace FancySignup.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "United States" },
                new Country { Id = 2, Name = "Canada" },
                new Country { Id = 3, Name = "Mexico" },
                new Country { Id = 4, Name = "United Kingdom" },
                new Country { Id = 5, Name = "Germany" }
            );
        }
    }
}
