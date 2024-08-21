using Core.Dto;
using FluentValidation;

namespace Core.Validations
{
    public class InvestimentValidation : AbstractValidator<InvestmentDto>
    {
        public InvestimentValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("A propriedade id é obrigatório e não pode estar vazio.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("A propriedade nome é obrigatório")
                .Matches(@"\S+").WithMessage("O valor da propriedade nome não pode estar vazio ou conter apenas espaços em branco.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("A propriedade tipo_investimento é obrigatório.");

            RuleFor(x => x.PurchaseDate)
                .NotEmpty().WithMessage("A propriedade data_compra é obrigatória")
                .Must(BeAValidPurchaseDate).WithMessage("O valor da propriedade data_compra não pode estar no futuro.");

            RuleFor(x => x.MaturityDate)
                .NotEmpty().WithMessage("A propriedade data_vencimento é obrigatória.")
                .Must(BeAValidMaturityDate).WithMessage("O valor da propriedade data_vencimento deve estar no futuro.")
                .Must(BeAfterPurchaseDate).WithMessage("O valor da propriedade data_vencimento deve ser posterior ao valor da propriedade data_compra.");

            RuleFor(x => x.InterestRate)
                .GreaterThanOrEqualTo(0).WithMessage("O valor da propriedade taxa_juros deve ser igual ou maior que zero.")
                .LessThanOrEqualTo(100).WithMessage("O valor da propriedade taxa_juros deve ser menor ou igual a 100.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("O valor da propriedade preco_unitario deve ser maior ou igual a zero.");
        }

        private bool BeAValidPurchaseDate(DateTime date) => date <= DateTime.Now;

        private bool BeAValidMaturityDate(DateTime date) => date > DateTime.Now;

        private bool BeAfterPurchaseDate(InvestmentDto dto, DateTime maturityDate) => maturityDate > dto.PurchaseDate;
    }
}