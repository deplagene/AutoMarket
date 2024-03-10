using AutoMarketProject.Application.Cars.Commands.CreateCar;
using FluentValidation;

namespace AutoMarketProject.Application.Orders.Commands.CreateOrder;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.Cars)
            .NotNull();
    }
}