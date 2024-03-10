using FluentValidation;

namespace AutoMarketProject.Application.Users.Commands.RegisterUser;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(u => u.FullName).NotEmpty();
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.Email).NotEmpty()
            .EmailAddress();
    }
}