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
        /// <summary>
        /// Asynchronously retrieves an aggregate root by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the aggregate root to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the aggregate root if found, otherwise an empty option.</returns>
        Task<Result<Option<TAggregateRoot>>> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    }
}
