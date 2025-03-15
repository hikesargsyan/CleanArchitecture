using App.Domain.Entities;

namespace App.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record TodoItemModel(int Id, int ListId, string? Title, bool IsDone);
