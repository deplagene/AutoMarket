using CSharpFunctionalExtensions;
using MediatR;

namespace AutoMarketProject.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}