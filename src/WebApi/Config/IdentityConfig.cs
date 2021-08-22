using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;

namespace WebApi.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            string mySqlConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection)));

            services.AddIdentity<IdentityUser, IdentityRole>()                
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()                
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
