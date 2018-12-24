using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Entities;
using SectorSelection.Mapper;
using SectorSelection.WebApi.Extensions;

namespace SectorSelection.WebApi
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
            services.AddMvc();
            services.AddServices();
            services.AddSingleton(AutoMapperFactory.CreateAndConfigure());
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<DbContext>(sp => sp.GetService<ApplicationDbContext>());

            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
                if (!context.Sectors.Any())
                {
                    context.Sectors.Add(new Entities.Sectors.Sector()
                    {
                        ParentId = null,
                        SectorName = "Test"
                    });
                    context.SaveChanges();
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
