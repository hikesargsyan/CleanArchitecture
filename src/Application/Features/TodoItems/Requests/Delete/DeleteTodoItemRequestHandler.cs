using App.Application._Common.Exceptions;
using App.Application._Common.Interfaces;
using App.Application.TodoItems.Commands.DeleteTodoItem;

public class DeleteTodoItemRequestHandler(IAppDbContext context) : IRequestHandler<DeleteTodoItemRequest>
{
    public async Task Handle(DeleteTodoItemRequest request, CancellationToken cancellationToken)
    {
        var entity = await context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException();
        }

        context.TodoItems.Remove(entity);
        
        await context.SaveChangesAsync(cancellationToken);
    }

}
