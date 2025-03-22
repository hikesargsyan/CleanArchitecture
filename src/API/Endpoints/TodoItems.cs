using App.API.Infrastructure;
using App.Application.Common.Models;
using App.Application.Features.TodoItems.Models;
using App.Application.Features.TodoItems.Requests.Create;
using App.Application.Features.TodoItems.Requests.Delete;
using App.Application.Features.TodoItems.Requests.Update;
using App.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Http.HttpResults;

namespace App.API.Endpoints;

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

    public async Task<Created<Guid>> CreateTodoItem(ISender sender, CreateTodoItemRequest command)
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
