namespace Infrastructure.EmailDelivery
{
    public class SmtpSettings
    {
        public required string Host { get; set; }

        public int Port { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public bool EnabledSsl { get; set; }
    }
}