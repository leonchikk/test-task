using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SiteMeasure.Domain.Models.DTOs;
using SiteMeasure.Domain.Services.Interfaces;

namespace SiteMeasure.Domain.Services.Implementations
{
    public class UtilService : IUtilService
    {
        private readonly WebClient _webClient;

        public UtilService()
        {
            _webClient = new WebClient();
        }

        public async Task<IEnumerable<SiteMapDtoModel>> GetSiteMapByUrlAsync(string requestedUrl)
        {
            _webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");
            _webClient.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");
            string htmlString = await _webClient.DownloadStringTaskAsync(requestedUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var scheme = new Uri(requestedUrl).Scheme;
            var host = new Uri(requestedUrl).Host;
            var baseUrl = $"{scheme}://{host}";

            var siteMapLinks = htmlDoc.DocumentNode
                .Descendants()
                .Where(n => n.Name == "a" && n.Attributes.Any(x => x.Name == "href"))
                .Select(n => {

                    var routeUrl = n.Attributes["href"].Value;

                    return new SiteMapDtoModel()
                    {
                        RequestedUrl = requestedUrl,
                        BaseUrl = baseUrl,
                        RouteUrl = routeUrl
                    };
                 })
                .ToList();

            return siteMapLinks;
        }
    }
}
