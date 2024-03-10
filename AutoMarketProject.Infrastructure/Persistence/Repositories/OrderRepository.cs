using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace AutoMarketProject.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
      
    public void Add(Order entity)
    {
        _dbContext.Orders.Add(entity);
    }

    public void Update(Order entity)
    {
        _dbContext.Orders.Update(entity);
    }

    public void Remove(Order entity)
    {
        _dbContext.Orders.Remove(entity);
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<PagedList<Order>> GetAllUsePagination(OrderParameters orderParameters, CancellationToken cancellationToken)
    {
        var orders = await _dbContext.Orders
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return PagedList<Order>
            .ToPagedList(orders, orderParameters.PageNumber, orderParameters.PageSize);
    }

    public async Task CancelOrder(Guid orderId, CancellationToken cancellationToken = default)
    {
        var order = await _dbContext.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
        if (order == null)
        {
            throw new InvalidOperationException("Order not found");
        }
        
        order.SetStatus(OrderStatus.Cancelled);
        
        Update(order);
    }

    public async Task<IEnumerable<Order>> GetOrdersToCancel(CancellationToken cancellationToken = default)
    {
        var ordersToCancel = await _dbContext.Orders
            .Where(o => o.OrderStatus == OrderStatus.Created && o.CreatedAt.AddMinutes(30) < DateTime.UtcNow)
            .ToListAsync(cancellationToken);

        return ordersToCancel;
    }
}