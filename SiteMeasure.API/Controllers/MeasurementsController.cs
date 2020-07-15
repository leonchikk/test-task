using Microsoft.AspNetCore.Mvc;
using SiteMeasure.Domain.Models.RequestModels;
using SiteMeasure.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace SiteMeasure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IUtilService _utilService;
        private readonly IMeasurementService _measurementService;

        public MeasurementsController(IUtilService utilService, IMeasurementService measurementService)
        {
            _utilService = utilService;
            _measurementService = measurementService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeMeasurement([FromBody] MakeMeasurementRequestModel requestModel)
        {
            var sitemapUrls = await _utilService.GetSiteMapByUrlAsync(requestModel.RequestedUrl);
            var result = await _measurementService.GetMeasurementsBySiteMapUrlsAsync(sitemapUrls);

            return Ok(result);
        }
    }
}