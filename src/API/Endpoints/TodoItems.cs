using App.Application._Common.Models;
using App.Application.TodoItems.Commands.CreateTodoItem;
using App.Application.TodoItems.Commands.DeleteTodoItem;
using App.Application.TodoItems.Commands.UpdateTodoItem;
using App.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Http.HttpResults;

namespace App.Web.Endpoints;

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoItemsWithPagination)
            .MapPost(CreateTodoItem)
            .MapPut(UpdateTodoItem, "{id}")
            .MapDelete(DeleteTodoItem, "{id}");
    }

    public async Task<Ok<PaginatedList<TodoItemModel>>> GetTodoItemsWithPagination(ISender sender, [AsParameters] GetPaginatedTodoItemsRequest query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateTodoItem(ISender sender, CreateTodoItemRequest command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(TodoItems)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateTodoItem(ISender sender, int id, UpdateTodoItemRequest request)
    {
        if (id != request.Id) return TypedResults.BadRequest();

        await sender.Send(request);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemRequest(id));

        return TypedResults.NoContent();
    }
}
