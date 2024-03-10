using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Domain.Cars;
using Microsoft.EntityFrameworkCore;

namespace AutoMarketProject.Infrastructure.Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CarRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Получить машину по индефикатору
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Car?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Cars
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id,  cancellationToken);
    }
    
    
    /// <summary>
    /// Получить список машин используя пагинацию
    /// </summary>
    /// <param name="carParameters"></param>
    /// <returns></returns>
    public async Task<PagedList<Car>> GetAllUsePagination(CarParameters carParameters, CancellationToken cancellationToken)
    {
        var cars = await _dbContext.Cars
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return PagedList<Car>
            .ToPagedList(cars, carParameters.PageNumber, carParameters.PageSize);
    }
    
    /// <summary>
    /// Получить список машин
    /// </summary>
    /// <returns></returns>
    public async Task<IReadOnlyCollection<Car>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Cars
            .AsNoTracking().ToListAsync(cancellationToken);
    }

    
    /// <summary>
    /// Добавить машину
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Add(Car entity)
    {
        _dbContext.Cars.Add(entity);
    }

    
    /// <summary>
    /// Обновить машину
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(Car entity)
    {
        _dbContext.Cars.Update(entity);
    }

    
    /// <summary>
    /// Удалить машину
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Remove(Car entity)
    {
        _dbContext.Cars.Remove(entity);
    }
}