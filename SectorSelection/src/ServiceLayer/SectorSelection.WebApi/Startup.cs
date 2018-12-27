using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SectorSelection.Dtos;
using SectorSelection.Entities;
using SectorSelection.Mapper;
using SectorSelection.TestDataGenerator;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var context = new ApplicationDbContext())
                {
                    context.Database.EnsureCreated();
                    if (!context.Sectors.Any())
                    {
                        InsertSectors(context);
                        context.SaveChanges();
                    }
                }
            }

            app.UseMvc();
        }

        private void InsertSectors(ApplicationDbContext context)
        {
            List<SectorDto> sectors = SectorDataGenerator.GenerateSectors();
            foreach (var sector in sectors)
            {
                Sector newSector = new Sector()
                {
                    IsActive = sector.IsActive,
                    SectorName = sector.SectorName,
                    Value = sector.Value,
                    Parent = context.Sectors.Local.FirstOrDefault(x => x.Value == sector.ParentId)
                };
                context.Sectors.Add(newSector);
            }
        }
    }
}