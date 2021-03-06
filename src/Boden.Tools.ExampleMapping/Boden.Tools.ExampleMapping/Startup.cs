using Boden.Tools.ExampleMapping.Business;
using Boden.Tools.ExampleMapping.Business.Data;
using Boden.Tools.ExampleMapping.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Boden.Tools.ExampleMapping
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSignalR();

            //services.AddScoped<ExampleMappingDbContext, InMemoryExampleMappingDbContext>();
            string connectionString = this.Configuration.GetValue<string>("connectionString");
            services.AddScoped<ExampleMappingDbContext, SqlServerExampleMappingDbContext>(sp => new SqlServerExampleMappingDbContext(connectionString));
            //services.AddScoped<ExampleMappingDbContext, InMemoryExampleMappingDbContext>();
            InMemoryExampleMappingDbContext.ResetRoot();

            services.AddScoped<MappingStoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSpaStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<TestHub>("/testhub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = new TimeSpan(0, 0, 90);
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
