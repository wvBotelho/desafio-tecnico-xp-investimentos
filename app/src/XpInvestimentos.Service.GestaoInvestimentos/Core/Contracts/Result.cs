using System.Diagnostics.CodeAnalysis;

namespace Core.Contracts
{
    [ExcludeFromCodeCoverage]
    public abstract class Either<TLeft, TRight>
    {
        public bool IsLeft { get; set; }

        public bool IsRight { get; set; }

        public abstract object GetValue();
    }

    [ExcludeFromCodeCoverage]
    public class Success<L, R> : Either<L, R>
    {
        private R Right { get; }

        public Success(R right)
        {
            IsLeft = false;

            IsRight = true;

            Right = right;
        }

        public static Either<L, R> Ok(R ok) => new Success<L, R>(ok);

        public override object GetValue() => Right!;
    }

    [ExcludeFromCodeCoverage]
    public class Failure<L, R> : Either<L, R>
    {
        private L Left { get; }

        public Failure(L left)
        {
            IsLeft = true;

            IsRight = false;

            Left = left;
        }

        public static Either<L, R> Fail(L fail) => new Failure<L, R>(fail);

        public override object GetValue() => Left!;
    }
}