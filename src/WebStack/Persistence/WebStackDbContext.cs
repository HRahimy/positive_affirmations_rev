using Microsoft.EntityFrameworkCore;
using WebStack.Application.Common.Interfaces;
using WebStack.Common;
using WebStack.Domain.Common;
using WebStack.Domain.Entities;

namespace WebStack.Persistence
{
    public class WebStackDbContext : DbContext, IWebStackDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public WebStackDbContext(DbContextOptions<WebStackDbContext> options)
            : base(options)
        {
        }

        public WebStackDbContext(
            DbContextOptions<WebStackDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Affirmation> Affirmations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebStackDbContext).Assembly);
        }
    }
}
