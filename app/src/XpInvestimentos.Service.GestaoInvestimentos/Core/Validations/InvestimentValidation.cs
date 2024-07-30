using Core.Dto;
using FluentValidation;

namespace Core.Validations
{
    public class InvestimentValidation : AbstractValidator<InvestmentDto>
    {
        public InvestimentValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty();

            RuleFor(i => i.Name)
                .NotEmpty();

            RuleFor(i => i.Type)
                .NotNull();

            RuleFor(i => i.PurchaseDate)
                .NotEmpty();

            RuleFor(i => i.MaturityDate)
                .NotEmpty();

            RuleFor(i => i.InterestRate)
                .NotEmpty();

            RuleFor(i => i.Price)
                .NotEmpty();
        }
    }
}