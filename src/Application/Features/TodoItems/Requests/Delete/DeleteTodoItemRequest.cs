using App.Application._Common.Interfaces;
using App.Domain.Events;

namespace App.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemRequest(int Id) : IRequest;

