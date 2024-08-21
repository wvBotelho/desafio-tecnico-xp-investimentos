using Core.Contracts;
using Core.Dto;
using Core.Errors;

namespace Core.Interfaces
{
    public interface IFinancialProductUsecase
    {
        Task<Either<Error, IEnumerable<InvestmentDto>>> GetAllProducts();

        Task<Either<Error, InvestmentDto>> GetProductById(Guid id);

        Task<Either<Error, InvestmentDto>> AddProduct(InvestmentDto product);

        Task<Either<Error, InvestmentDto>> UpdateProduct(InvestmentDto product);

        Task<Either<Error, bool>> DeleteProduct(Guid id);
    }
}