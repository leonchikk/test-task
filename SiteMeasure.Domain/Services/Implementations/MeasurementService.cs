using SiteMeasure.Core.DataAccess;
using SiteMeasure.Core.Entities;
using SiteMeasure.Domain.Models.DTOs;
using SiteMeasure.Domain.Models.ViewModels;
using SiteMeasure.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SiteMeasure.Domain.Services.Implementations
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RequestedUrl> _requestUrlsRepository;

        public MeasurementService(IUnitOfWork unitOfWork, IRepository<RequestedUrl> requestUrlsRepository)
        {
            _unitOfWork = unitOfWork;
            _requestUrlsRepository = requestUrlsRepository;
        }

        public async Task<IEnumerable<MeasurementViewModel>> GetMeasurementsBySiteMapUrlsAsync(IEnumerable<SiteMapDtoModel> sitemapDtos)
        {
            var result = new List<MeasurementViewModel>();
            var sitemapUrlsList = sitemapDtos.ToList();

            var measurementTasks = new List<Task<MeasurementDtoModel>>();

            for (int i = 0; i < sitemapUrlsList.Count; i++)
                measurementTasks.Add(MakeMeasurement(sitemapUrlsList[i]));

            await Task.WhenAll(measurementTasks);

            var tasksResult = measurementTasks.Select(x => x.Result);
            var groupedMeasurements = tasksResult.GroupBy(x => x.RequestedUrl);

            var entitiesToSave = new List<RequestedUrl>();

            foreach (var measurement in groupedMeasurements)
            {
                var requstedUrl = new RequestedUrl()
                {
                    Url = measurement.Key
                };

                var sitemaps = measurement.Select(x =>
                {
                    var sitemap = new Sitemap();
                    sitemap.SitemapUrl = x.RouteUrl;
                    sitemap.Measurements.Add(new SitemapMeasure()
                    {
                        TimeSpan = TimeSpan.FromMilliseconds(x.TimeSpanInMilliseconds)
                    });

                    return sitemap;
                });

                foreach (var sitemap in sitemaps)
                {
                    requstedUrl.SitemapUrls.Add(sitemap);
                }

                entitiesToSave.Add(requstedUrl);
            }

            _requestUrlsRepository.AddOrUpdate(entitiesToSave);
            await _unitOfWork.SaveChangesAsync();

            result.AddRange(tasksResult.Select(x => new MeasurementViewModel()
            {
                BaseUrl = x.BaseUrl,
                RouteUrl = x.RouteUrl,
                TimeSpanInMilliseconds = x.TimeSpanInMilliseconds
            }));

            return result;
        }

        private async Task<MeasurementDtoModel> MakeMeasurement(SiteMapDtoModel model)
        {
            var result = new MeasurementDtoModel
            {
                RequestedUrl = model.RequestedUrl,
                BaseUrl = model.BaseUrl,
                RouteUrl = model.RouteUrl
            };

            try
            {
                var stopWatch = new Stopwatch();
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(model.BaseUrl)
                };

                stopWatch.Start();

                var response = await httpClient.GetAsync(model.RouteUrl);

                stopWatch.Stop();

                result.TimeSpanInMilliseconds = stopWatch.ElapsedMilliseconds;
            }
            catch (Exception)
            {
                result.TimeSpanInMilliseconds = -1;
                return result;
            }

            return result;
        }
    }
}
