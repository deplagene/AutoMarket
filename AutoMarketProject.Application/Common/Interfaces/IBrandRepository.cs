using AutoMarketProject.Application.Common.Interfaces.Base;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Domain.Cars;

namespace AutoMarketProject.Application.Common.Interfaces;

public interface IBrandRepository : IWriteRepository<Brand>, IReadRepository<Brand, Guid>
{
    Task<PagedList<Brand>> GetAllUsePagination(BrandParameters brandParameters, CancellationToken cancellationToken);

    Task<Brand?> GetBrandByName(string brandName, CancellationToken cancellationToken = default);
}