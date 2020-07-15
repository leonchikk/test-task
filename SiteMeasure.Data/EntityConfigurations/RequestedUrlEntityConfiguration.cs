using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteMeasure.Core.Entities;

namespace SiteMeasure.Data.EntityConfigurations
{
    public class RequestedUrlEntityConfiguration : IEntityTypeConfiguration<RequestedUrl>
    {
        public void Configure(EntityTypeBuilder<RequestedUrl> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.SitemapUrls)
                   .WithOne(e => e.RequestedUrl)
                   .HasForeignKey(e => e.RequestedUrlId);
        }
    }
}
