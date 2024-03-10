namespace AutoMarketProject.Application.Common.Interfaces.Base;

public interface IReadRepository<TEntity, TKey>
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    
}