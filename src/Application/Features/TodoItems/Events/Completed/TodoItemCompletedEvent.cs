using App.Domain.Common;
using App.Domain.Entities;

namespace App.Application.Features.TodoItems.Events.Completed;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
