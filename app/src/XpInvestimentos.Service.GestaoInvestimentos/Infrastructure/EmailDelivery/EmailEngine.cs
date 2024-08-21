using System.Net;
using System.Net.Mail;
using Core.Contracts;
using Core.Errors;
using Core.Interfaces;
using Microsoft.Extensions.Options;

namespace Infrastructure.EmailDelivery
{
    public class EmailEngine(IOptions<SmtpSettings> options, ILoggerGenerator logger) : IEmailEngine
    {
        private readonly SmtpSettings _settings = options.Value;

        private readonly ILoggerGenerator _logger = logger;

        public async Task<Either<Error, bool>> SendNotificationAsync(MailMessage message)
        {
            try
            {
                using SmtpClient client = new() 
                {
                    Host = _settings.Host,
                    Port = _settings.Port,
                    Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                    EnableSsl = _settings.EnabledSsl
                };

                _logger.Debug($"enviando email de {message.To} para {message.From}");

                await client.SendMailAsync(message);

                _logger.Debug("envio realizado com sucesso");

                return Success<Error, bool>.Ok(true);
            }
            catch(Exception e)
            {
                _logger.Error("erro ao fazer disparo de email", e);

                return Failure<Error, bool>.Fail(SmtpError.OperationError("EmailEngine.SendNotificationAsync", e));
            }
        }
    }
}