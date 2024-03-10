using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Infrastructure.Persistence;

namespace AutoMarketProject.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}