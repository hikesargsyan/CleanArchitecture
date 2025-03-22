using App.Domain.Common;
using App.Domain.Entities;

namespace App.Application.Features.TodoItems.Events.Created;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
