using System;

namespace SiteMeasure.Core.Entities
{
    public class SitemapMeasure : BaseEntity
    {
        public TimeSpan TimeSpan { get; set; }

        public Guid SitemapId { get; set; }
        public Sitemap Sitemap { get; set; }
    }
}
