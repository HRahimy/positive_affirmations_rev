using Duende.IdentityServer;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebStack.Infrastructure.Identity;
public class IdentityConfigurationDbContextInitialiser
{
    private readonly ILogger<IdentityConfigurationDbContextInitialiser> _logger;
    private readonly IdentityConfigurationDbContext _context;

    public IdentityConfigurationDbContextInitialiser(ILogger<IdentityConfigurationDbContextInitialiser> logger, IdentityConfigurationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the identity server configuration database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the identity server configuration database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Resources
        if (!_context.ApiResources.Any())
        {
            var resourceEntities = IdentityConfiguration
                .GetApiResources()
                .Select(e => e.ToEntity())
                .ToList();

            _context.ApiResources.AddRange(resourceEntities);

            await _context.SaveChangesAsync();
        }

        // Clients
        if (!_context.Clients.Any())
        {
            var clientEntities = IdentityConfiguration
                .GetClients()
                .Select(e => e.ToEntity())
                .ToArray();

            _context.Clients.AddRange(clientEntities);

            await _context.SaveChangesAsync();
        }
    }
}
