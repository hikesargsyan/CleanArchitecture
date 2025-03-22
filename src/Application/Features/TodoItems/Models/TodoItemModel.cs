namespace App.Application.Features.TodoItems.Models;

public record TodoItemModel(Guid Id, int ListId, string? Title, bool IsDone);
