using App.Application.Common.Models;
using App.Application.Features.TodoItems.Models;

namespace App.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetPaginatedTodoItemsRequest(int ListId, int PageNumber, int PageSize)
    : IRequest<PaginatedList<GetTodoItemModel>>;
