namespace Overseer.Abstractions
{
    public class Option<T>
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
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value) => Option<T>.Some(value);
        public static Option<T> None<T>() => Option<T>.None();
    }
}
