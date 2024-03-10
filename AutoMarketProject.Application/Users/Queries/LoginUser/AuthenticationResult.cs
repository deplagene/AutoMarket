using AutoMarketProject.Presentation.Users;

namespace AutoMarketProject.Application.Users.Queries.LoginUser;

public record AuthenticationResult(
    UserLoginDto UserLoginDto,
    string Token);