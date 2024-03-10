using AutoMapper;
using AutoMarketProject.Application.Common.Authentication;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Users;
using AutoMarketProject.Presentation.Users;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoMarketProject.Application.Users.Commands.RegisterUser;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = User.CreateUser(
            request.FullName,
            request.Email,
            request.Password);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return Result.Failure<User>($"{nameof(user)}");
        }
        
        // Добавить роль
        
        return Result.Success();
    }
}