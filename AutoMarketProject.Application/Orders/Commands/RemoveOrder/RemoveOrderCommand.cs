using AutoMarketProject.Application.Messaging;

namespace AutoMarketProject.Application.Orders.Commands.RemoveOrder;

public sealed record RemoveOrderCommand(Guid Id) : ICommand;