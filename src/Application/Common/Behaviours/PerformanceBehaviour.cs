using System.Diagnostics;
using App.Application._Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace App.Application._Common.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse>(ILogger<TRequest> logger, ICurrentUser currentUser)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private const int LongRunningRequestThresholdMs = 500;
    private readonly Stopwatch _timer = new();

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= LongRunningRequestThresholdMs)
        {
            return response;
        }

        var requestName = typeof(TRequest).Name;
        var userId = currentUser.Id ?? string.Empty;

        logger.LogWarning("API Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
            requestName, elapsedMilliseconds, userId, request);

        return response;
    }
}
