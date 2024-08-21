namespace Core.Errors
{
    public class Error(string code, string description, Exception? e)
    {
        public string Code { get; set; } = code;

        public string Description { get; set; } = description;

        public Exception? Ex { get; set; } = e;

        public static Error None() => new(string.Empty, string.Empty, default);

        public static Error UnexpectedError(string code, Exception e) => new(code, "an unexpected error occurred.", e);
    }
}