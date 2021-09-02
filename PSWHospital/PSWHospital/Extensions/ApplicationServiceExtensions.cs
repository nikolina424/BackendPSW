using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSWHospital.Models;

namespace PSWHospital.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MyDbContext>(options =>
                    options.UseMySql(ConfigurationExtensions.GetConnectionString(config, "MyDbContextConnectionString")));

            return services;
        }
    }
}
