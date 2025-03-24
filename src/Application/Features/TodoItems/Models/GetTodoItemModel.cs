namespace App.Application.Features.TodoItems.Models;

public record GetTodoItemModel(Guid Id, int ListId, string? Title, bool IsDone);
