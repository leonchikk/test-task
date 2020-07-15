using Microsoft.EntityFrameworkCore;
using SiteMeasure.Core.Entities;
using SiteMeasure.Data.EntityConfigurations;

namespace SiteMeasure.Data
{
    public class SiteMeasureDbContext : DbContext
    {
        public SiteMeasureDbContext(DbContextOptions<SiteMeasureDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<RequestedUrl> RequestedUrls { get; set; }
        public virtual DbSet<Sitemap> Sitemaps { get; set; }
        public virtual DbSet<SitemapMeasure> SitemapMeasures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestedUrlEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SitemapEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SitemapMeasureEntityConfiguration());
        }
    }
}
