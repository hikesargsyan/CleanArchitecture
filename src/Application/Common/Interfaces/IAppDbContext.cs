using App.Domain.Entities;

namespace App.Application._Common.Interfaces;

public interface IAppDbContext
{
    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
