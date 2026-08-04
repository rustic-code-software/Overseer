namespace Overseer.Abstractions
{
    /// <summary>
    /// Represents an active record pattern for managing domain models.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IActiveRecord<TModel, TId>
        where TModel : IAggregateRoot<TId>
    {
        /// <summary>
        /// Gets the model associated with this active record.
        /// </summary>
        TModel Model { get; }

        /// <summary>
        /// Asynchronously retrieves the model by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the model to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The asynchronous task representing the operation.</returns>
        Task GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Asynchronously saves the model to the data store.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The asynchronous task representing the operation.</returns>
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
