using AutoMapper;
using LightpointGlobalTestApp.Extensions;
using LightpointGlobalTestApp.Mapper;
using LightpointGlobalTestApp.Model;
using LightpointGlobalTestApp.Services.Contracts;
using LightpointGlobalTestApp.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LightpointGlobalTestApp
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
            services.AddCors();

            services.AddDbContext<ApplicationDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Injecting services
            services.AddTransient<IShopsService, ShopsService>();
            services.AddTransient<IItemsService, ItemsService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDatabaseContext dbcontext)
        {
            dbcontext.Database.Migrate();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDatabaseContext>().Started();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.ConfigureExceptionHandler();

            app.UseMvc();
        }
    }
}
