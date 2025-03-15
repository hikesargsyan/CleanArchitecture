using App.Application._Common.Models;

namespace App.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetPaginatedTodoItemsRequest(int ListId, int PageNumber, int PageSize)
    : IRequest<PaginatedList<TodoItemModel>>;
