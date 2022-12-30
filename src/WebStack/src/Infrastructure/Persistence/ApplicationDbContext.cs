using System.Reflection;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebStack.Application.Common.Interfaces;
using WebStack.Domain.Entities;
using WebStack.Infrastructure.Common;
using WebStack.Infrastructure.Identity;
using WebStack.Infrastructure.Persistence.Interceptors;

namespace WebStack.Infrastructure.Persistence;

// References to WIP solution for resolving entity mapping issues during database initialization:
// https://github.com/dotnet/aspnetcore/issues/44990#issuecomment-1318124064
// https://stackoverflow.com/questions/71827951/asp-net-core-web-api-how-to-resolve-detected-package-version-outside-of-depend
// Final outcome:
// Accepting setting version of package 'Duende.IdentityServer.EntityFramework' to 6.0.4 as a temporary solution for now.
// TODO: Update Identity related packages once an update is released that implements the latest interface of ApiAuthorizationDbContext that includes the ServerSideSessions property
public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        // Addressing issue with SnakeCaseNamingConvention not applying to Identity
        // tables as specified here:
        // https://github.com/efcore/EFCore.NamingConventions/issues/2#issuecomment-575306675
        // Below solution identified and adapted from:
        // https://andrewlock.net/customising-asp-net-core-identity-ef-core-naming-conventions-for-postgresql/
        // https://medium.com/@aspram.shadyan.dev/identityserver4-ef-core-naming-conventions-adapted-for-postgresql-29a138bd26bb
        builder.ConvertToSnakeCase();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
