using FluentValidation;

namespace AutoMarketProject.Application.Cars.Commands.CreateCar;

public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c => c.Brand)
            .NotNull();
        RuleFor(c => c.Description)
            .MaximumLength(750);
        RuleFor(c => c.Model)
            .NotEmpty().Length(1, 50);
        RuleFor(c => c.Price)
            .GreaterThanOrEqualTo(1);
    }
}