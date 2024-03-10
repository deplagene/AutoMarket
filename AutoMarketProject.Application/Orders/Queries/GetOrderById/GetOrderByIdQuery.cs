using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Presentation.Orders;

namespace AutoMarketProject.Application.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(Guid Id) : IQuery<OrderDto>;