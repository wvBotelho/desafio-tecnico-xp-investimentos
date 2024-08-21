namespace Core.Interfaces
{
    public interface IEmailDeliveryService
    {
        Task SendDailyNotification();
    }
}