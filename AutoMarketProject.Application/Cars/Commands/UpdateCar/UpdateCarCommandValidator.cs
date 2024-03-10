using AutoMarketProject.Application.Cars.Commands.DeleteCar;
using AutoMarketProject.Presentation.Cars;
using FluentValidation;

namespace AutoMarketProject.Application.Cars.Commands.UpdateCar;

public sealed class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
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