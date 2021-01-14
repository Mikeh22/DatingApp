using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions // static means we dont need a new instance of the class 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) // what to we want to return from this IService collection
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection")); // Set connection string from our appsettings.json
            });

            return services;
        }
    }
}