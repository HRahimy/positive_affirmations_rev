using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStack.Application.Common.Interfaces;

namespace WebStack.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebStackDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("WebStackDatabase"))
                    .UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IWebStackDbContext>(provider => provider.GetService<WebStackDbContext>());

            return services;
        }
    }
}
