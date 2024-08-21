using Core.Errors;

namespace Infrastructure.EmailDelivery
{
    public class SmtpError(string code, string description, Exception e) : Error(code, description, e)
    {
        public static SmtpError OperationError(string code, Exception e) => new(code, "error executing the operation to sending email.", e);
    }
}