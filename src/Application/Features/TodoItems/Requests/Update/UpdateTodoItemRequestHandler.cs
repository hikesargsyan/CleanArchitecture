using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;

namespace App.Application.Features.TodoItems.Requests.Update;

public class UpdateTodoItemRequestHandler(IAppDbContext context) : IRequestHandler<UpdateTodoItemRequest>
{
    public async Task Handle(UpdateTodoItemRequest request, CancellationToken cancellationToken)
    {
        var todoItem = await context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        if (todoItem == null)
        {
            throw new NotFoundException(nameof(todoItem));
        }

        todoItem.Title = request.Title;
        todoItem.IsDone = request.IsDone;

        await context.SaveChangesAsync(cancellationToken);
    }
}
