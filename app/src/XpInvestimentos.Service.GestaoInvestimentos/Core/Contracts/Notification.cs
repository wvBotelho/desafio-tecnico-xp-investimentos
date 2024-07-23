namespace Core.Contracts
{
    public class Notification
    {
        public required string Email { get; set; }

        public bool Trigger { get; set; }

        public string Topic { get; set; } = string.Empty;

        public string Environment { get; set; } = string.Empty;
    }
}