using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Domain.Cars;
using AutoMarketProject.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace AutoMarketProject.Infrastructure.Persistence.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
    
    /// <summary>
    /// Добавить бренд
    /// </summary>
    /// <param name="entity">бренд</param>
    public void Add(Brand entity)
    {
        _dbContext.Brands.Add(entity);
    }
    
    
    /// <summary>
    /// Обновить бренд
    /// </summary>
    /// <param name="entity">бренд</param>
    public void Update(Brand entity)
    {
        _dbContext.Brands.Update(entity);
    }
    
    
    /// <summary>
    /// Удалить бренд
    /// </summary>
    /// <param name="entity">бренд</param>
    public void Remove(Brand entity)
    {
        _dbContext.Brands.Remove(entity);
    }

    
    /// <summary>
    /// Найти бренд по индетификатору
    /// </summary>
    /// <param name="id">Индетификатор бренда</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Brand?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    
    /// <summary>
    /// Список брендов
    /// </summary>
    /// <param name="brandParameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PagedList<Brand>> GetAllUsePagination(BrandParameters brandParameters, CancellationToken cancellationToken)
    {
        var brands = await _dbContext.Brands
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return PagedList<Brand>
            .ToPagedList(brands, brandParameters.PageNumber, brandParameters.PageSize);
    }

    public async Task<Brand?> GetBrandByName(string brandName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.BrandName == brandName, cancellationToken);
    }
}