using System.Reflection;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IPersistedGrantDbContext, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        _operationalStoreOptions = operationalStoreOptions;
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    /// <summary>
    /// Gets or sets the user sessions.
    /// </summary>
    /// <value>
    /// The keys.
    /// </value>
    public DbSet<ServerSideSession> ServerSideSessions { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{PersistedGrant}"/>.
    /// </summary>
    public DbSet<PersistedGrant> PersistedGrants { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{DeviceFlowCodes}"/>.
    /// </summary>
    public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{Key}"/>.
    /// </summary>
    public DbSet<Key> Keys { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
        builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);

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
