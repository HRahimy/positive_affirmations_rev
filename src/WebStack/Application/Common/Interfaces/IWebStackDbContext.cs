using Microsoft.EntityFrameworkCore;
using WebStack.Domain.Entities;

namespace WebStack.Application.Common.Interfaces
{
    public interface IWebStackDbContext
    {
        DbSet<Affirmation> Affirmations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

