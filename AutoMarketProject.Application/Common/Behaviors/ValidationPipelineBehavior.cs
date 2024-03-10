using AutoMarketProject.Application.Common.Exceptions;
using AutoMarketProject.Application.Messaging;
using FluentValidation;
using MediatR;

namespace AutoMarketProject.Application.Common.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : class, ICommand<TResponse>
{
     private readonly IEnumerable<IValidator<TRequest>> _validators;

     public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) 
          => _validators = validators;
     
     public async Task<TResponse> Handle(TRequest request, 
          RequestHandlerDelegate<TResponse> next, 
          CancellationToken cancellationToken)
     {
          if (!_validators.Any())
          {
               return await next();
          }

          var context = new ValidationContext<TRequest>(request);

          var errorDictionary = _validators
               .Select(x => x.Validate(context))
               .SelectMany(x => x.Errors)
               .Where(x => x != null)
               .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessage) => new
                    {
                         Key = propertyName,
                         Values = errorMessage.Distinct().ToArray()
                    })
               .ToDictionary(x => x.Key, x => x.Values);

          if (errorDictionary.Any())
          {
               throw new ValidationAppException(errorDictionary);
          }

          return await next();
     }
}