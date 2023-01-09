using Microsoft.EntityFrameworkCore;
using WebStack.Domain.Entities;

namespace WebStack.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Affirmation> Affirmations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
