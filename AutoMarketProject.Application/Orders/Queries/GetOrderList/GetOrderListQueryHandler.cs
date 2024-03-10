using AutoMapper;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Presentation.Orders;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Orders.Queries.GetOrderList;

public class GetOrderListQueryHandler : IQueryHandler<GetOrderListQuery, PagedList<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<OrderDto>>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllUsePagination(request.OrderParameters, cancellationToken);

        var orderDto = _mapper.Map<PagedList<OrderDto>>(orders);

        return orderDto;
    }
}