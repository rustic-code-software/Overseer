namespace Overseer.Abstractions
{
    /// <summary>
    /// Represents an entity with a unique identifier.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IIdentity<TId>
    {
        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        TId Id { get; }
    }
}
