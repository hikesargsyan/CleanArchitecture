using App.Application.Common.Interfaces;
using App.Application.Features.TodoItems.Events.Created;
using App.Domain.Entities;

namespace App.Application.Features.TodoItems.Requests.Create;

public class CreateTodoItemRequestHandler(IAppDbContext context) : IRequestHandler<CreateTodoItemRequest, Guid>
{
    public async Task<Guid> Handle(CreateTodoItemRequest request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            IsDone = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        context.TodoItems.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
