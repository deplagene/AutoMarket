using AutoMapper;
using AutoMarketProject.Application.Common.Authentication;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Users;
using AutoMarketProject.Presentation.Users;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;

namespace AutoMarketProject.Application.Users.Queries.LoginUser;

public class LoginQueryHandler : IQueryHandler<LoginQuery, AuthenticationResult>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            return Result.Failure<AuthenticationResult>($"{nameof(user)} can't be found");
        }

        var result = await _signInManager
            .CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
        {
            return Result.Failure<AuthenticationResult>("Wrong login or password");
        }

        var userDto = _mapper.Map<UserLoginDto>(user);

        // Генерить токен
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(userDto, token);
    }
}