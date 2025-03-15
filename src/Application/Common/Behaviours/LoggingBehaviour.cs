using App.Application._Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace App.Application._Common.Behaviours;

public class LoggingBehaviour<TRequest>(ILogger<TRequest> logger, ICurrentUser currentUser)
    : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger = logger;

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = currentUser.Id ?? string.Empty;

        _logger.LogInformation("API Request: {Name}, {@UserId}: {@Request}", requestName, userId, request);

        return Task.CompletedTask;
    }
}
