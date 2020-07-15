using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteMeasure.Core.Entities;

namespace SiteMeasure.Data.EntityConfigurations
{
    public class SitemapMeasureEntityConfiguration : IEntityTypeConfiguration<SitemapMeasure>
    {
        public void Configure(EntityTypeBuilder<SitemapMeasure> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Sitemap)
                   .WithMany(e => e.Measurements)
                   .HasForeignKey(e => e.SitemapId);
        }
    }
}
