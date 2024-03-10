using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Cars;
using AutoMarketProject.Domain.Users;

namespace AutoMarketProject.Application.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(User Customer, List<Car> Cars) : ICommand;