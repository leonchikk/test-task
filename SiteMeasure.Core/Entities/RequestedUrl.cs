using System.Collections.Generic;

namespace SiteMeasure.Core.Entities
{
    public class RequestedUrl : BaseEntity
    {
        public RequestedUrl()
        {
            SitemapUrls = new HashSet<Sitemap>();
        }

        public string Url { get; set; }

        public ICollection<Sitemap> SitemapUrls { get; set; }
    }
}
