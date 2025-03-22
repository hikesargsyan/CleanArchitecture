using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;

namespace App.Application.Features.TodoItems.Requests.Delete;

public class DeleteTodoItemRequestHandler(IAppDbContext context) : IRequestHandler<DeleteTodoItemRequest>
{
    public async Task Handle(DeleteTodoItemRequest request, CancellationToken cancellationToken)
    {
        var todoItem = await context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        if (todoItem == null)
        {
            throw new NotFoundException(nameof(todoItem));
        }

        context.TodoItems.Remove(todoItem);
        
        await context.SaveChangesAsync(cancellationToken);
    }

}
