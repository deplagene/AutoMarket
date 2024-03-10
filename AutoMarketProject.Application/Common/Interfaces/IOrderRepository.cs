using AutoMarketProject.Application.Common.Interfaces.Base;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Domain.Orders;

namespace AutoMarketProject.Application.Common.Interfaces;

public interface IOrderRepository : IWriteRepository<Order>, IReadRepository<Order, Guid>
{
    Task<PagedList<Order>> GetAllUsePagination(OrderParameters orderParameters, CancellationToken cancellationToken);

    Task CancelOrder(Guid orderId, CancellationToken cancellationToken = default);

    Task<IEnumerable<Order>> GetOrdersToCancel(CancellationToken cancellationToken = default);
}