using App.Application._Common.Interfaces;

namespace App.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemRequest(int Id, string? Title, bool IsDone) : IRequest;
