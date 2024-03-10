namespace AutoMarketProject.Domain.Abstractions;

public class EntityBase { }

public class EntityBase<TKey> : EntityBase where TKey : IEquatable<TKey>
{
    
}