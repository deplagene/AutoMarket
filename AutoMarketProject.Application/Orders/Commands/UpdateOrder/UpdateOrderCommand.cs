using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Orders;

namespace AutoMarketProject.Application.Orders.Commands.UpdateOrder;

public sealed record UpdateOrderCommand(Guid Id, 
    OrderStatus? OrderStatus): ICommand;