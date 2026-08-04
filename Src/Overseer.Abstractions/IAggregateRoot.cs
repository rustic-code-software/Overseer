
namespace Overseer.Abstractions
{
    /// <summary>
    /// Represents an aggregate root with a unique identifier.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IAggregateRoot<TId> : IIdentity<TId>
    {
    }
}
