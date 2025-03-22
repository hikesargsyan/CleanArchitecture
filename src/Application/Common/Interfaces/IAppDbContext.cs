using App.Domain.Entities;

namespace App.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
