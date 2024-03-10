using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AutoMarketProject.Application.Messaging;

public interface ICommand : IRequest<Result>
{
}
public interface ICommand<TResponse> : IRequest<Result<TResponse>>;