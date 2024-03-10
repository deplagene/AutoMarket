using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AutoMarketProject.Application.Common.Behaviors;

public class RequestLoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : IResult
{
    private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public RequestLoggingPipelineBehavior(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
       _logger.LogInformation(
           "Starting request {@RequestName}, {@DateTimeUtc}",
           typeof(TRequest).Name,
               DateTime.UtcNow);

       var result = await next();

       if (result.IsFailure)
       {
           _logger.LogError(
               "Request failure {@RequestName}, {@DateTimeUtc}",
               typeof(TRequest).Name,
               DateTime.UtcNow
               );
       }
       
       _logger.LogInformation(
           "Completed request {@RequestName}, {@DateTimeUtc}",
           typeof(TRequest).Name,
           DateTime.UtcNow);
       
       return result;
    }
}