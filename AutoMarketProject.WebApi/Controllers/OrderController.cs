using AutoMarketProject.Application.Orders.Commands.CreateOrder;
using AutoMarketProject.Application.Orders.Commands.RemoveOrder;
using AutoMarketProject.Application.Orders.Commands.UpdateOrder;
using AutoMarketProject.Application.Orders.Queries.GetOrderById;
using AutoMarketProject.Application.Orders.Queries.GetOrderList;
using AutoMarketProject.Application.Pagination;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarketProject.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllOrders(OrderParameters orderParameters,
        CancellationToken cancellationToken = default)
    {
        var query = new GetOrderListQuery(orderParameters);

        var response = await _mediator.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpGet("{orderId:guid}")]
    public async Task<IActionResult> GetOrderById(Guid orderId,
        CancellationToken cancellationToken)
    {
        var query = new GetOrderByIdQuery(orderId);

        var response = await _mediator.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    [HttpDelete("{orderId:guid}")]
    public async Task<IActionResult> DeleteOrder(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var command = new RemoveOrderCommand(orderId);

        var response = await _mediator.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    [HttpPatch("{orderId:guid")]
    public async Task<IActionResult> UpdateOrder(Guid orderId,
        UpdateOrderCommand request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateOrderCommand(
            request.Id,
            request.OrderStatus);

        var response = await _mediator.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : NotFound(response.Error);
        ;
    }
}