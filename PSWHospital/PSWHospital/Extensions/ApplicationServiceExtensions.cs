using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSWHospital.Models;
using PSWHospital.Services;
using PSWHospital.Services.impl;

namespace PSWHospital.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<MyDbContext>(options =>
                    options.UseMySql(ConfigurationExtensions.GetConnectionString(config, "MyDbContextConnectionString")));

            return services;
        }
    }
}
