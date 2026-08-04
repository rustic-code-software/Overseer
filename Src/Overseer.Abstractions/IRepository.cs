namespace Overseer.Abstractions
{
    /// <summary>
    /// Represents a repository for managing aggregate roots.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IRepository<TAggregateRoot, TId>
        where TAggregateRoot : IAggregateRoot<TId>
    {

    }
}
