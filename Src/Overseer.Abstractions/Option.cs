using System;
using System.Collections.Generic;

namespace Overseer.Abstractions
{
    public class Option<T> : IEquatable<Option<T>>
    {
        public bool HasValue { get; private set; }
        public T? Value { get; private set; }

        private Option() { }

        public static Option<T> Some(T value) => new Option<T> { HasValue = true, Value = value };

        public static Option<T> None() => new Option<T> { HasValue = false, Value = default };

        public Option<TResult> Map<TResult>(Func<T, TResult> map) =>
            HasValue ? Option<TResult>.Some(map(Value!)) : Option<TResult>.None();

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none) =>
            HasValue ? some(Value!) : none();

        public void Match(Action<T> some, Action none)
        {
            if (HasValue) some(Value!);
            else none();
        }

        public bool Equals(Option<T>? other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (HasValue != other.HasValue) return false;

            return EqualityComparer<T>.Default.Equals(Value!, other.Value!);
        }

        public override bool Equals(object? obj) => obj is Option<T> other && Equals(other);

        public override int GetHashCode() => HasValue ? EqualityComparer<T>.Default.GetHashCode(Value!) : 0;

        public static bool operator ==(Option<T>? left, Option<T>? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Option<T>? left, Option<T>? right) => !(left == right);
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value) => Option<T>.Some(value);
        public static Option<T> None<T>() => Option<T>.None();
    }
}
