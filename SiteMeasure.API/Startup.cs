using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiteMeasure.Core.DataAccess;
using SiteMeasure.Data;
using SiteMeasure.Data.DataAccess;
using SiteMeasure.Domain.Services.Implementations;
using SiteMeasure.Domain.Services.Interfaces;

namespace SiteMeasure.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(option => option.EnableEndpointRouting = false);
            services.AddDbContext<SiteMeasureDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("local")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUtilService, UtilService>();
            services.AddScoped<IMeasurementService, MeasurementService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
