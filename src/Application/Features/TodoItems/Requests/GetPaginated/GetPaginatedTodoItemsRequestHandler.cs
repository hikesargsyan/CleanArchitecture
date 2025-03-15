using App.Application._Common.Interfaces;
using App.Application._Common.Models;
using App.Application._Common.Mappings;

namespace App.Application.TodoItems.Queries.GetTodoItemsWithPagination;

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
