using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minesweeper.Data;

namespace Minesweeper.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDataAccess(configuration);
            return services;
        }

        public static IApplicationBuilder AddStartup(this IApplicationBuilder app)
        {
            app.MigrateDb();
            return app;
        }
    }
}
