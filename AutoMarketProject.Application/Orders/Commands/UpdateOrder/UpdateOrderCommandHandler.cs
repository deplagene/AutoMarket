using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Orders;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            return Result.Failure<Order>($"{nameof(order)} is null");
        }

        if (request.OrderStatus is not null)
        {
            order.SetStatus(request.OrderStatus.Value);
        }
        
        _orderRepository.Update(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}