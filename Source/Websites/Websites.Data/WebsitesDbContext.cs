using Microsoft.EntityFrameworkCore;
using Websites.Data.Models;

namespace Websites.Data
{
    public class WebsitesDbContext : DbContext
    {

        public WebsitesDbContext(DbContextOptions<WebsitesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Website> Websites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Website>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
