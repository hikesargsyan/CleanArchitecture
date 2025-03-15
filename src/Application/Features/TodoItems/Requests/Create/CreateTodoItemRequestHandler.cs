using App.Application._Common.Interfaces;
using App.Domain.Entities;
using App.Domain.Events;

namespace App.Application.TodoItems.Commands.CreateTodoItem;


public class CreateTodoItemRequestHandler : IRequestHandler<CreateTodoItemRequest, int>
{
    private readonly IAppDbContext _context;

    public CreateTodoItemRequestHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTodoItemRequest request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            IsDone = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.TodoItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
