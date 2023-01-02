using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebStack.Application.Common.Interfaces;
using WebStack.Infrastructure.Files;
using WebStack.Infrastructure.Identity;
using WebStack.Infrastructure.Persistence;
using WebStack.Infrastructure.Persistence.Interceptors;
using WebStack.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Addressing issue with Npgsql database driver throwing error when using
        // DateTime with Kind=Local as described here:
        // https://github.com/skoruba/IdentityServer4.Admin/issues/963
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        ///////////////////////////////////////////////////////////////////////////

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("WebStackDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                options.UseSnakeCaseNamingConvention();
            });
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
            .AddInMemoryApiResources(IdentityConfiguration.GetApiResources())
            .AddInMemoryApiScopes(IdentityConfiguration.GetApiScopes())
            .AddInMemoryClients(IdentityConfiguration.GetClients());
        // Due to issues with ApiAuthorization package from microsoft having dependency issues with Duende.IdentityServer,
        // avoiding using persisted configuration stores using EF Core until issue is resolved on their side.
        // See notes in ApplicationDbContext file for more details.
        /*            .AddConfigurationStore<IdentityConfigurationDbContext>(options =>
                    {
                        options.DefaultSchema = "identity_config";
                        options.ConfigureDbContext = builder =>
                        builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                                sql => sql.MigrationsAssembly(typeof(IdentityConfigurationDbContext).Assembly.FullName)
                                .MigrationsHistoryTable("__EFMigrationsHistory", "identity_config"));
                    });*/

        /*services.AddScoped<IdentityConfigurationDbContextInitialiser>();*/

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
