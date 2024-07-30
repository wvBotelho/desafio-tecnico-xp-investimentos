namespace Core.Errors
{
    public sealed record Error(string Code, string Description, Exception? E)
    {
        public static Error None() => new(string.Empty, string.Empty, default);

        public static Error UnexpectedError(string code, Exception e) => new(code, "an unexpected error occurred.", e);
    }

    public static class MongoOperationError
    {
        public static Error MongoException(string code, Exception e) => new(code, "error executing the operation in the database.", e);
    }

    public static class FinancialProductError
    {
        public static Error DatabaseError(string code) => new(code, "error executing the operation in the database.", null);

        public static Error FinancialProductNotFound(string code) => new(code, "financial product not found", null);

        public static Error FinancialProductInvalid(string code) => new(code, "financial product invalid", null);
    }
}