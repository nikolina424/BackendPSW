using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSWHospital.Extensions;
using PSWHospital.Repositories;
using PSWHospital.Repositories.impl;

namespace PSWHospital
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //repositories
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
          

            //services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddApplicationServices(_config);
            services.AddControllers();
            services.AddIdentityServices(_config);
            services.AddCors();
            services.AddControllers()
             .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new IntToStringConverter()));
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
