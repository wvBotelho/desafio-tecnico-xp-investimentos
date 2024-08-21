using System.Net.Mail;
using Core.Contracts;
using Core.Errors;

namespace Core.Interfaces
{
    public interface IEmailEngine
    {
        Task<Either<Error, bool>> SendNotificationAsync(MailMessage message);
    }
}