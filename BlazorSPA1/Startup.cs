using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorSPA1.Data;
using Microsoft.EntityFrameworkCore;
using BlazorSPA1.DbContexts;
using BlazorSPA1.Services;
using Blazui.Component;
using BlazorStrap;
using BlazorPrettyCode;

namespace BlazorSPA1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazuiServices();

            services.AddBlazorPrettyCode(defaults =>
            {
                defaults.DefaultTheme = "SolarizedDark";
                defaults.ShowLineNumbers = true;
                defaults.IsDevelopmentMode = true;
            });

            services.AddBootstrapCss();

            services.AddSingleton<WeatherForecastService>();

            services.AddDbContext<SqlDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("SqlDbContext")));

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddServerSideBlazor(options => options.DetailedErrors = true);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
