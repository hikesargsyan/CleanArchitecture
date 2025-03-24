using App.Application.Common.Models;
using App.Application.Features.TodoItems.Models;
using App.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Http.HttpResults;

namespace App.API.Endpoints.TodoItems;

public class GetPaginatedTodoItemsEndpoint : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app
            .MapGet("/todo/paginated", ExecuteAsync)
            .RequireAuthorization()
            .WithOpenApi();
    }

    private async Task<Ok<PaginatedList<GetTodoItemModel>>> ExecuteAsync(
        ISender sender,
        [AsParameters] GetPaginatedTodoItemsRequest query
    )
    {
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }
}
