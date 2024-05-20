using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain;

namespace News.Persistence.EntityTypeConfigurations
{
    internal class NewsConfiguration : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.HasKey(news => news.Id);
            builder.HasIndex(news => news.Id).IsUnique();
        }
    }
}
