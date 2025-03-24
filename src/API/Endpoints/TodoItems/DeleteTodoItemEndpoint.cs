using App.Application.Features.TodoItems.Requests.Delete;
using Microsoft.AspNetCore.Http.HttpResults;

namespace App.API.Endpoints.TodoItems;

public class DeleteItemEndpoint : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app
            .MapDelete("/todo/{id}", ExecuteAsync)
            .RequireAuthorization()
            .WithOpenApi();
    }

    private async Task<NoContent> ExecuteAsync(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemRequest(id));

        return TypedResults.NoContent();
    }
}
