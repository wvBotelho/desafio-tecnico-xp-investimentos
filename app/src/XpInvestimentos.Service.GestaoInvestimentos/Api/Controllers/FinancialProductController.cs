using Core.Contracts;
using Core.Dto;
using Core.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("produtos_financeiros")]
    public class FinancialProductController(IFinancialProductUsecase usecase, ILoggerGenerator logger) : BaseController(logger)
    {
        private readonly IFinancialProductUsecase _usecase = usecase;

        private readonly ILoggerGenerator _logger = logger;

        [HttpGet]
        [Route("investimentos")]
        public async Task<IActionResult> GetAllProducts()
        {
            _logger.Debug($"requisição GET {nameof(GetAllProducts)} recebida");

            Either<Error, IEnumerable<InvestmentDto>> result = await _usecase.GetAllProducts();

            return Ok(result);
        }

        [HttpGet]
        [Route("investimentos/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            _logger.Debug($"requisição GET {nameof(GetProduct)} recebida com parâmetro {id}");

            Either<Error, InvestmentDto> result = await _usecase.GetProductById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("investimentos")]
        public async Task<IActionResult> AddProduct(InvestmentDto product)
        {
            _logger.Debug($"requisição POST {nameof(AddProduct)} recebida");

            Either<Error, InvestmentDto> result = await _usecase.AddProduct(product);

            return Ok(result);
        }

        [HttpPut]
        [Route("investimentos")]
        public async Task<IActionResult> UpdateProduct(InvestmentDto product)
        {
            _logger.Debug($"requisição POST {nameof(UpdateProduct)} recebida");

            Either<Error, InvestmentDto> result = await _usecase.UpdateProduct(product);

            return Ok(result);
        }

        [HttpDelete]
        [Route("investimentos/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            _logger.Debug($"requisição POST {nameof(DeleteProduct)} recebida");

            Either<Error, bool> result = await _usecase.DeleteProduct(id);

            return Ok(result);
        }
    }
}