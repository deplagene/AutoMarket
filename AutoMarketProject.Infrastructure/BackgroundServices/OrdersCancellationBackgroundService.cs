using AutoMarketProject.Application.Common.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoMarketProject.Infrastructure.BackgroundServices;

public class OrdersCancellationBackgroundService : BackgroundService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<OrdersCancellationBackgroundService> _logger;

    public OrdersCancellationBackgroundService(IOrderRepository orderRepository,
        ILogger<OrdersCancellationBackgroundService> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var ordersToCancel = await _orderRepository.GetOrdersToCancel(stoppingToken);

            foreach (var order in ordersToCancel)
            {
                try
                {
                    await _orderRepository.CancelOrder(order.Id, stoppingToken);
                    _logger.LogInformation("Order {OrderId} has been cancelled", order.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to cancel order {OrderId}", order.Id);
                }
            }

            await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
        }
    }
}