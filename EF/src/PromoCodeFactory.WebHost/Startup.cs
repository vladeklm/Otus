using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess;
using PromoCodeFactory.DataAccess.Data;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.Servicies.Abstractions;
using PromoCodeFactory.Servicies.Implementations;
using PromoCodeFactory.WebHost.Settings;

namespace PromoCodeFactory.WebHost
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var applicationSettings = Configuration.Get<ApplicationSettings>();
            services.AddControllers();
            services.AddScoped(typeof(IRepository<Employee>), (x) =>
                new InMemoryRepository<Employee>(FakeDataFactory.Employees));
            services.AddScoped(typeof(IRepository<Role>), (x) =>
                new InMemoryRepository<Role>(FakeDataFactory.Roles));
            services.AddScoped<IRepository<Role>, RoleRepository>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped(typeof(IRepository<Preference>), (x) =>
                new InMemoryRepository<Preference>(FakeDataFactory.Preferences));
            services.AddScoped(typeof(IRepository<Customer>), (x) =>
                new InMemoryRepository<Customer>(FakeDataFactory.Customers));

            services.AddOpenApiDocument(options =>
            {
                options.Title = "PromoCode Factory API Doc";
                options.Version = "1.0";
            });

            services.AddDbContext<AppDbContext>(optionsBuilder
                => optionsBuilder
                    .UseNpgsql(applicationSettings.ConnectionString));
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
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi(x =>
            {
                x.DocExpansion = "list";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}