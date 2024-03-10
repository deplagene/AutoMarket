using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Users;

namespace AutoMarketProject.Application.Users.Commands.RegisterUser;

public record RegisterCommand(
    FullName FullName,
    string Email,
    string Password): ICommand;