using Core.Enum;
using Core.Validations;
using FluentValidation.Results;

namespace Core.Dto
{
    public class InvestmentDto
    {
        public Guid Id { get; set; }
        
        public required string Name { get; set; }

        public InvestimentType Type { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public decimal InterestRate { get; set; }

        public decimal Price { get; set; }

        public bool IsValid()
        {
            InvestimentValidation validator = new();

            ValidationResult result = validator.Validate(this);

            return result.IsValid;
        }
    }
}