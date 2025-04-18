using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            var connectionDb = configuration.GetConnectionString("ConnectionDb");
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionDb, ServerVersion.AutoDetect(connectionDb))
            );

            return services;
        }
    }
}
