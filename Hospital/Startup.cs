using Hospital.Middlewares;
using Hospital.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital
{
    public class Startup
    {
        private IConfiguration config;
        public Startup(IConfiguration _config)
        {
            config = _config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalDBContext>(optionsAction => optionsAction.UseSqlServer(config["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IRepository, Repository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Hospital}/{action=ShowAllPatient}/{page}/{sortState}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Hospital}/{action=MainPage}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller}/{action}/{id?}"
                    );
            });
            SeedData.EnsureDoctors(app);
        }
    }
}
