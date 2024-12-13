using DemoApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Infrastructure.Data
{
    public class DemoAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
