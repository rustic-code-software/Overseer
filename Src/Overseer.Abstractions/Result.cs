using System.ComponentModel.DataAnnotations;

namespace Overseer.Abstractions
{
    public class Result<TValue>
    {
        public bool Succeeded { get; private set; }
        public TValue? Value { get; private set; }
        public ValidationResult? Error { get; private set; }

        private Result() { }

        public static Result<TValue> Success(TValue value) =>
            new()
            {
                Succeeded = true,
                Value = value
            };
        public static Result<TValue> Fail(ValidationResult error) =>
            new()
            {
                Succeeded = false,
                Value = default,
                Error = error
            };

        public Result<TNew> MapError<TNew>() =>
            new Result<TNew> {
                Succeeded = false,
                Value = default,
                Error = this.Error
            };
    }

    public static class Result
    {
        public static Result<TValue> Success<TValue>(TValue value) => Result<TValue>.Success(value);

        public static Result<TValue> Fail<TValue>(ValidationResult error) => Result<TValue>.Fail(error);
    }
}
