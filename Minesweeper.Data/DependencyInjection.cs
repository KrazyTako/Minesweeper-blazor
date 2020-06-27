using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minesweeper.Data.Entities;

namespace Minesweeper.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MinesweeperDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<MinesweeperDbContext>();

            return services;
        }

        public static IApplicationBuilder MigrateDb(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<MinesweeperDbContext>().Database.Migrate();
            }

            return app;
        }
    }
}
