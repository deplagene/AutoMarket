using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Presentation.Orders;

namespace AutoMarketProject.Application.Orders.Queries.GetOrderList;

public sealed record GetOrderListQuery(OrderParameters OrderParameters) : IQuery<PagedList<OrderDto>>;