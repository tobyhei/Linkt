using System;

namespace Linkt.Repository
{
    public static class Result
    {
        public static Result<T> Unit<T>() => Result<T>.None;

        public static Result<T> Some<T>(T value) => value;

        public static Result<TResult> Bind<TIn, TResult>(
            Func<TIn, Result<TResult>> bindFunc, Result<TIn> lhs)
                => lhs.HasValue ? bindFunc(lhs.Value) : Unit<TResult>();
    }

    public struct Result<T>
    {
        private readonly T value;

        private Result(T value) => this.value = value;

        public bool HasValue => value != null;

        public T Value => HasValue ? value : throw
            new InvalidOperationException("Cannot access value of Result.None");

        public static Result<T> None = default;

        public static implicit operator Result<T>(T value) => new Result<T>(value);
    }
}