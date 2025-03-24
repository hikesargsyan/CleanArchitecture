using App.Application.Features.TodoItems.Requests.Create;
using Microsoft.AspNetCore.Http.HttpResults;

namespace App.API.Endpoints.TodoItems;

public class CreateTodoItemEndpoint : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app
            .MapPost("/todo", ExecuteAsync)
            .RequireAuthorization()
            .WithOpenApi();
    }

    private async Task<Created<Guid>> ExecuteAsync(ISender sender, CreateTodoItemRequest command)
    {
        var id = await sender.Send(command);
        return TypedResults.Created($"/{nameof(TodoItems)}/{id}", id);
    }
}
