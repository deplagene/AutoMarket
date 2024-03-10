using AutoMapper;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Presentation.Orders;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            return Result.Failure<OrderDto>($"{nameof(order)} is null");
        }

        var orderDto = _mapper.Map<OrderDto>(order);

        return orderDto;
    }
}