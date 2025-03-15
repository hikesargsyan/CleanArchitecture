using App.Application._Common.Exceptions;
using App.Application._Common.Interfaces;

namespace App.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemRequestHandler(IAppDbContext context) : IRequestHandler<UpdateTodoItemRequest>
{
    public async Task Handle(UpdateTodoItemRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException();
        }

        entity.Title = request.Title;
        entity.IsDone = request.IsDone;

        await context.SaveChangesAsync(cancellationToken);
    }
}
