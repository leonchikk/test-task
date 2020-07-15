using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteMeasure.Core.Entities;

namespace SiteMeasure.Data.EntityConfigurations
{
    public class SitemapEntityConfiguration : IEntityTypeConfiguration<Sitemap>
    {
        public void Configure(EntityTypeBuilder<Sitemap> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.RequestedUrl)
                   .WithMany(e => e.SitemapUrls)
                   .HasForeignKey(e => e.RequestedUrlId);

            builder.HasMany(e => e.Measurements)
                   .WithOne(e => e.Sitemap)
                   .HasForeignKey(e => e.SitemapId);
        }
    }
}
