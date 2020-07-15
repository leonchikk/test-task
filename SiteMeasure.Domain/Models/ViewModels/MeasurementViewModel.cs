using System;

namespace SiteMeasure.Domain.Models.ViewModels
{
    public class MeasurementViewModel
    {
        public string BaseUrl { get; set; }
        public string RouteUrl { get; set; }
        public long TimeSpanInMilliseconds { get; set; }
    }
}
