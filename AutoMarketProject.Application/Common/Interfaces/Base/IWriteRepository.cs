namespace AutoMarketProject.Application.Common.Interfaces.Base;

public interface IWriteRepository<TEntity>
{
    void Add(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}