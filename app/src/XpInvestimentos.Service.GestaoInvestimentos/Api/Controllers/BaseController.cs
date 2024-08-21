using Application.Usecases;
using Core.Contracts;
using Core.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BaseController(ILoggerGenerator logger) : ControllerBase
    {
        private readonly ILoggerGenerator _logger = logger;
        
        public IActionResult Ok<T>(Either<Error, T> result)
        {
            if (result.IsLeft)
                return ErrorResult((Error)result.GetValue());

            _logger.Info("requisição concluida", result.GetValue());

            return Ok(new { result = result.GetValue() });
        }

        public IActionResult ErrorResult(Error error)
        {
            Type typeError = error.GetType();

            _logger.Info("erro executando a requisição", error);

            return typeError switch
            {
                Type t when t == typeof(FinancialProductNotFound) => NotFound(new { Code = StatusCodes.Status404NotFound, Message = "o recurso não foi encontrado", Error = error.Description }),
                Type t when t == typeof(DatabaseError) || t == typeof(FinancialProductInvalid) => BadRequest(new { Code = StatusCodes.Status400BadRequest, Message = "houve um problema ao fazer a requisição", Error = error.Description }),
                _ => StatusCode(StatusCodes.Status500InternalServerError, new { Code = StatusCodes.Status500InternalServerError, Message = "erro inesperado.", Error = error.Description })
            };
        }
    }
}