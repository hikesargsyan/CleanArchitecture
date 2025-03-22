namespace App.Application.Features.TodoItems.Requests.Update;

public record UpdateTodoItemRequest(int Id, string? Title, bool IsDone) : IRequest;
