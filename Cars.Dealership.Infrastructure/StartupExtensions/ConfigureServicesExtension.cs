using Cars.Dealership.Core.Domain.IdentityEntities;
using Cars.Dealership.Core.Domain.RepositoryContracts;
using Cars.Dealership.Core.ServiceContracts;
using Cars.Dealership.Core.Services;
using Cars.Dealership.Infrastructure.DatabaseContext;
using Cars.Dealership.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Cars.Dealership.Infrastructure.StartupExtensions
{
    public static class ConfigureServicesExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(
                       configuration.GetConnectionString("Default")
                    );
            });




            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);


            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
            .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>()
            .AddDefaultTokenProviders();





            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarAdderService, CarAdderService>();
            services.AddScoped<ICarGetterService, CarGetterService>();
            services.AddScoped<ICarDeleterService, CarDeleterService>();
            services.AddScoped<ICarUpdaterService, CarUpdaterService>();


            //services
            //    .AddIdentityCore<ApplicationUser>(options =>
            //    {
            //        options.User.RequireUniqueEmail = true;
            //        options.Password.RequireUppercase = true;
            //        options.Password.RequireNonAlphanumeric = true;
            //        options.Password.RequiredLength = 8; 
            //        options.Password.RequireDigit = true;
            //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5d);
            //    })
            //    .AddRoles<ApplicationRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

        }
    }
}
