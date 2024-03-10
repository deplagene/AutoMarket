using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Presentation.Users;

namespace AutoMarketProject.Application.Users.Queries.LoginUser;

public record LoginQuery(
    string Email,
    string Password) : IQuery<AuthenticationResult>;