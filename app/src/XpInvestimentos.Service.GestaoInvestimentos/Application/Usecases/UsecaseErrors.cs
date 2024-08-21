using System.Text;
using Core.Errors;
using FluentValidation.Results;

namespace Application.Usecases
{
    public class FinancialProductNotFound(string code, string description) : Error(code, description, null)
    {
        public static FinancialProductNotFound Create(string code) => new(code, "financial product not found");
    }

    public class DatabaseError(string code, string description) : Error(code, description, null)
    {
        public static DatabaseError Create(string code) => new(code, "error executing the operation in the database.");
    }

    public class FinancialProductInvalid(string code, string description) : Error(code, description, null)
    {
        public static FinancialProductInvalid Create(string code, List<ValidationFailure> errors)
        {
            StringBuilder builder = new();

            foreach(ValidationFailure error in errors)
            {
                builder.Append($"- Property {error.PropertyName} failed validation. Error: {error.ErrorMessage}. ");
            }

            return new(code, $"financial product invalid. {builder}");
        }
    }
}