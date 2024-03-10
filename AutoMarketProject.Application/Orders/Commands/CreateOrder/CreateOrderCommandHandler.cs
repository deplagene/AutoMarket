using AutoMarketProject.Application.Cars.Commands.CreateCar;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Orders;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.CreateOrder(
            request.Customer,
            request.Cars);
        
        _orderRepository.Add(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}