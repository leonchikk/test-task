using SiteMeasure.Domain.Models.DTOs;
using SiteMeasure.Domain.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMeasure.Domain.Services.Interfaces
{
    public interface IMeasurementService
    {
        Task<IEnumerable<MeasurementViewModel>> GetMeasurementsBySiteMapUrlsAsync(IEnumerable<SiteMapDtoModel> sitemapUrls);
    }
}
