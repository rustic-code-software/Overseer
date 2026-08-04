namespace Overseer.Abstractions
{
    /// <summary>
    /// Represents a void-like value (a singleton unit type).
    /// All instances are equal; use Unit.Value when a value is required.
    /// </summary>
    public readonly struct Unit : IEquatable<Unit>
    {
        public static readonly Unit Value = new Unit();

        public override string ToString() => "()";

        public bool Equals(Unit other) => true;

        public override bool Equals(object? obj) => obj is Unit;

        public override int GetHashCode() => 0;

        public static bool operator ==(Unit left, Unit right) => true;

        public static bool operator !=(Unit left, Unit right) => false;
    }
}
