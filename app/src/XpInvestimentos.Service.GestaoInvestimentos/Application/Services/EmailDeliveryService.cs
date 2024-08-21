using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using Core.Contracts;
using Core.Errors;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class EmailDeliveryService(
        IEmailEngine engine, 
        IMongoRepository repository,
        ILoggerGenerator logger) : IEmailDeliveryService
    {
        private readonly IEmailEngine _engine = engine;

        private readonly IMongoRepository _repository = repository;

        private readonly ILoggerGenerator _logger = logger;

        public async Task SendDailyNotification()
        {
            try
            {
                _logger.Debug("verificando produtos financeiros perto do vencimento");

                DateTime dateLimit = DateTime.UtcNow.AddDays(7);

                Expression<Func<InvestimentDocument, bool>> filter = a => a.IsActive && a.MaturityDate < dateLimit;

                Either<Error, IEnumerable<InvestimentDocument>> result = await _repository.FindAsync(filter);

                if (result.IsLeft)
                {
                    _logger.Warning("erro ao fazer a consulta", result.GetValue());

                    return;
                }                    

                IEnumerable<InvestimentDocument> documents = (IEnumerable<InvestimentDocument>)result.GetValue();

                List<InvestimentDocument> investimentsMaturity = [];
                
                StringBuilder body = new();

                foreach (InvestimentDocument doc in documents)
                {
                    body.AppendLine($"- O produto {doc.Name} está com vencimento próximo em {doc.MaturityDate}");
                }

                if (body.Length > 0)
                {
                    _logger.Debug("disparando alarme de produtos perto do vencimento", documents);

                    MailMessage message = new("wlourenzo97@gmail.com", "wagnerbotelho24@gmail.com")
                    {
                        Subject = "Produto(s) com vencimento(s) próximos",
                        SubjectEncoding = Encoding.UTF8,
                        Body = body.ToString(),
                        BodyEncoding = Encoding.UTF8
                    };

                    Either<Error, bool> resultEmail = await _engine.SendNotificationAsync(message);

                    if (resultEmail.IsLeft) {
                        _logger.Warning("algum problema foi identificado ao realizar operação de envio de email", result.GetValue());

                        return;
                    }

                    _logger.Debug("operação concluida");
                }
            }
            catch(Exception e)
            {
                _logger.Error($"houve um problema ao executar o método {nameof(SendDailyNotification)}. Erro: {e}");
            }
        }
    }
}