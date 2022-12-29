using System.Reflection;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using WebStack.Infrastructure.Common;

namespace WebStack.Infrastructure.Identity;
public class IdentityConfigurationDbContext : ConfigurationDbContext<IdentityConfigurationDbContext>
{
    public IdentityConfigurationDbContext(DbContextOptions<IdentityConfigurationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConvertToSnakeCase();
    }
}
