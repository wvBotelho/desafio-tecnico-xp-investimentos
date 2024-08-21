namespace Core.Contracts
{
    public class Log
    {
        public string Class { get; set; } = string.Empty;

        public string Method { get; set; } = string.Empty;

        public int Line { get; set; }

        public object? Data { get; set; }
    }
}