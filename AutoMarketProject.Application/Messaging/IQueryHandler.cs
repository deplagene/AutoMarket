using CSharpFunctionalExtensions;
using MediatR;

namespace AutoMarketProject.Application.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}