namespace App.Application.Features.TodoItems.Requests.Create;

public record CreateTodoItemRequest(int ListId, string? Title) : IRequest<Guid>;
