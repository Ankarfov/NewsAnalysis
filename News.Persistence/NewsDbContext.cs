using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Domain;
using News.Persistence.EntityTypeConfigurations;

namespace News.Persistence
{
    public class NewsDbContext : DbContext, INewsDbContext
    {
        public DbSet<New> News { get; set; }

        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NewsConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
