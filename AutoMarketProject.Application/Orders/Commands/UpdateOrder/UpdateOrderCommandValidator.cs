using FluentValidation;

namespace AutoMarketProject.Application.Orders.Commands.UpdateOrder;

public sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(o => o.OrderStatus)
            .IsInEnum();
    }
}