using App.Application._Common.Interfaces;
using App.Domain.Entities;
using App.Domain.Events;

namespace App.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemRequest(int ListId, string? Title) : IRequest<int>;
