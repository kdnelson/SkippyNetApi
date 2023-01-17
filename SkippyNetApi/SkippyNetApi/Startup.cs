using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkippyNetApi.DataAccess.Repositories;
using SkippyNetApi.Helpers.Common;
using SkippyNetApi.Helpers.Work;
using SkippyNetApi.Interfaces.Common;
using SkippyNetApi.Interfaces.Work;
using System;

namespace SkippyNetApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
            });

            // Register IOCs
            //

            // Common
            //
            services.AddScoped<IResponseDto, ResponseDto>();
            services.AddScoped<IResponseValidationDto, ResponseValidationDto>();

            // Work
            //
            services.AddScoped<IWorkHelper, WorkHelper>();
            services.AddScoped<IWorkMappingHelper, WorkMappingHelper>();
            services.AddScoped<IWorkValidationHelper, WorkValidationHelper>();
            services.AddScoped<IWorkRepository, WorkRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
