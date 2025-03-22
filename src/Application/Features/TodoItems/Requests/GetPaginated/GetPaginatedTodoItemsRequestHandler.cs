using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Models;
using App.Application.Features.TodoItems.Models;
using App.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace App.Application.Features.TodoItems.Requests.GetPaginated;

public class GetTodoItemsWithPaginationQueryHandler(IAppDbContext context)
    : IRequestHandler<GetPaginatedTodoItemsRequest, PaginatedList<TodoItemModel>>
{
    public async Task<PaginatedList<TodoItemModel>> Handle(GetPaginatedTodoItemsRequest request,
        CancellationToken cancellationToken)
    {
        return await context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .Select(x => new TodoItemModel(x.Id, x.ListId, x.Title, x.IsDone))
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
