using AutoMarketProject.Domain.Users;

namespace AutoMarketProject.Application.Common.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}