using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CarTelemetry.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CarTelemetry
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
            services.AddRazorPages();

            services.AddDbContext<CarTelemetryContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CarTelemetryContext")));

            services.AddControllers(); //Very important to start the REST-Controller
            services.AddRouteAnalyzer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/routes", request =>
                {
                    request.Response.Headers.Add("content-type", "application/json");

                    var ep = endpoints.DataSources.First().Endpoints.Select(e => e as RouteEndpoint);
                    return request.Response.WriteAsync(
                        JsonSerializer.Serialize(
                            ep.Select(e => new
                            {
                                Method = ((HttpMethodMetadata)e.Metadata.First(m => m.GetType() == typeof(HttpMethodMetadata))).HttpMethods.First(),
                                Route = e.RoutePattern.RawText
                            })
                        )
                    );
                });
                endpoints.MapRazorPages();
            });
        }
    }
}
