using System;
using System.Collections.Generic;

namespace SiteMeasure.Core.Entities
{
    public class Sitemap : BaseEntity
    {
        public Sitemap()
        {
            Measurements = new HashSet<SitemapMeasure>();
        }

        public string SitemapUrl { get; set; }

        public Guid RequestedUrlId { get; set; }
        public RequestedUrl RequestedUrl { get; set; }

        public ICollection<SitemapMeasure> Measurements { get; set; }
    }
}
