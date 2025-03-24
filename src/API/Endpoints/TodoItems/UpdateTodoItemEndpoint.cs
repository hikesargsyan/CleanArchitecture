using App.Application.Common.Models;
using App.Application.Features.TodoItems.Models;
using App.Application.Features.TodoItems.Requests.Update;
using App.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Http.HttpResults;

namespace App.API.Endpoints.TodoItems;

public class UpdateTodoItemEndpoint : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app
            .MapPut("/todo/{id}", ExecuteAsync)
            .RequireAuthorization()
            .WithOpenApi();
    }


    private async Task<Results<NoContent, BadRequest>> ExecuteAsync(
        ISender sender,
        int id,
        UpdateTodoItemModel request)
    {
        await sender.Send(new UpdateTodoItemRequest(id, request.Title, request.IsDone));

        return TypedResults.NoContent();
    }
}
