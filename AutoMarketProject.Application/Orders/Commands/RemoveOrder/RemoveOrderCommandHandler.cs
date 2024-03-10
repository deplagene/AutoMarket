using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Orders;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Orders.Commands.RemoveOrder;

public class RemoveOrderCommandHandler : ICommandHandler<RemoveOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            return Result.Failure<Order>($"{nameof(order)} is null");
        }
        
        _orderRepository.Remove(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}