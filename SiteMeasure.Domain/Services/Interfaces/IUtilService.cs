using SiteMeasure.Domain.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMeasure.Domain.Services.Interfaces
{
    public interface IUtilService
    {
        Task<IEnumerable<SiteMapDtoModel>> GetSiteMapByUrlAsync(string requestedUrl);
    }
}
