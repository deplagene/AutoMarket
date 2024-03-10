using AutoMarketProject.Application.Common.Interfaces.Base;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Domain.Cars;

namespace AutoMarketProject.Application.Common.Interfaces;

public interface ICarRepository : IReadRepository<Car, Guid>, IWriteRepository<Car>
{
    Task<PagedList<Car>> GetAllUsePagination(CarParameters carParameters, CancellationToken cancellationToken);
}