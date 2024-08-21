using System.Linq.Expressions;
using AutoMapper;
using Core.Contracts;
using Core.Dto;
using Core.Errors;
using Core.Interfaces;
using Core.Models;
using Core.Validations;
using FluentValidation.Results;
using MongoDB.Driver;

namespace Application.Usecases.FinancialProduct
{
    public class FinancialProductUsecase(
        IMongoRepository repository, 
        IMapper mapper, 
        InvestimentValidation validation,
        ILoggerGenerator logger) : IFinancialProductUsecase
    {
        private readonly IMongoRepository _repository = repository;

        private readonly IMapper _mapper = mapper;

        private readonly InvestimentValidation _validation = validation;

        private readonly ILoggerGenerator _logger = logger;

        public async Task<Either<Error, IEnumerable<InvestmentDto>>> GetAllProducts()
        {
            try
            {
                _logger.Debug("buscando todos os produtos financeiros");

                Expression<Func<InvestimentDocument, bool>> filter = a => a.IsActive;

                Either<Error, IEnumerable<InvestimentDocument>> result = await _repository.FindAsync(filter);

                if (result.IsLeft)
                {
                    _logger.Warning("houve um problema ao fazer a requisição no banco", result.GetValue());

                    return Failure<Error, IEnumerable<InvestmentDto>>.Fail(DatabaseError.Create("InvestimentsUsecase.GetAllProducts"));
                }

                IEnumerable<InvestimentDocument> documents = (IEnumerable<InvestimentDocument>)result.GetValue();

                _logger.Debug("mapeando dominio para contrato");

                IEnumerable<InvestmentDto> investiments = _mapper.Map<IEnumerable<InvestmentDto>>(documents);

                _logger.Debug("produtos encontrados", investiments);

                return Success<Error, IEnumerable<InvestmentDto>>.Ok(investiments);
            }
            catch(Exception e)
            {
                _logger.Error($"houve um problema ao executar o método {nameof(GetAllProducts)}. Erro: {e.Message}", e);

                return Failure<Error, IEnumerable<InvestmentDto>>.Fail(Error.UnexpectedError("InvestimentsUsecase.GetAllProducts", e));
            }
        }

        public async Task<Either<Error, InvestmentDto>> GetProductById(Guid id)
        {
            try
            {
                _logger.Debug($"buscando produto financeiro pelo id: {id}");

                Expression<Func<InvestimentDocument, bool>> filter = a => a.Id.Equals(id) & a.IsActive;

                Either<Error, IEnumerable<InvestimentDocument>> result = await _repository.FindAsync(filter);

                if (result.IsLeft)
                {
                    _logger.Warning("houve um problema ao fazer a requisição no banco", result.GetValue());

                    return Failure<Error, InvestmentDto>.Fail(DatabaseError.Create("InvestimentsUsecase.GetProductById"));
                }

                IEnumerable<InvestimentDocument> documents = (IEnumerable<InvestimentDocument>)result.GetValue();

                InvestimentDocument? document = documents.FirstOrDefault();

                if (document is null)
                {
                    _logger.Warning($"produto com id {id} não encontrado");

                    return Failure<Error, InvestmentDto>.Fail(FinancialProductNotFound.Create("InvestimentsUsecase.GetProductById"));
                }

                InvestmentDto product = _mapper.Map<InvestmentDto>(document);

                _logger.Debug("produto encontrado", product);

                return Success<Error, InvestmentDto>.Ok(product);
            }
            catch(Exception e)
            {
                _logger.Error($"houve um problema ao executar o método {nameof(GetProductById)}. Erro: {e.Message}", e);

                return Failure<Error, InvestmentDto>.Fail(Error.UnexpectedError("InvestimentsUsecase.GetProductById", e));
            }
        }

        public async Task<Either<Error, InvestmentDto>> AddProduct(InvestmentDto product)
        {
            try
            {
                _logger.Debug("validando contrato");

                ValidationResult validate = _validation.Validate(product);

                if (!validate.IsValid)
                {
                    _logger.Warning("produto invalido", validate.Errors.ToString()!);

                    return Failure<Error, InvestmentDto>.Fail(FinancialProductInvalid.Create("InvestimentsUsecase.AddProduct", validate.Errors));
                }

                _logger.Debug("mapeando contrato para entidade");

                InvestimentDocument investiment = _mapper.Map<InvestimentDocument>(product);

                _logger.Debug("inserindo entidade no banco");

                Either<Error, bool> result = await _repository.InsertAsync(investiment);

                if (result.IsLeft)
                {
                    _logger.Warning("houve um problema ao fazer a requisição no banco", result.GetValue());

                    return Failure<Error, InvestmentDto>.Fail(DatabaseError.Create("InvestimentsUsecase.AddProduct"));
                }

                bool status = (bool)result.GetValue();

                _logger.Debug($"operação de inserção concluida. Status: {status}");

                return Success<Error, InvestmentDto>.Ok(product);
            }
            catch(Exception e)
            {
                _logger.Error($"houve um problema ao executar o método {nameof(AddProduct)}. Erro: {e.Message}", e);

                return Failure<Error, InvestmentDto>.Fail(Error.UnexpectedError("InvestimentsUsecase.AddProduct", e));
            }
        }

        public async Task<Either<Error, InvestmentDto>> UpdateProduct(InvestmentDto product)
        {
            try 
            {
                _logger.Debug("validando contrato");

                ValidationResult validate = _validation.Validate(product);

                if (!validate.IsValid)
                {
                    _logger.Warning("produto invalido", validate.Errors.ToString()!);

                    return Failure<Error, InvestmentDto>.Fail(FinancialProductInvalid.Create("InvestimentsUsecase.UpdateProduct", validate.Errors));
                }

                _logger.Debug("mapeando contrato para entidade");

                InvestimentDocument investiment = _mapper.Map<InvestimentDocument>(product);

                _logger.Debug("atualizando entidade no banco");

                Expression<Func<InvestimentDocument, bool>> filter = a => a.Id.Equals(product.Id) & a.IsActive;

                Either<Error, bool> result = await _repository.ReplaceAsync(filter, investiment);

                if (result.IsLeft)
                {
                    _logger.Warning("houve um problema ao fazer a requisição no banco", result.GetValue());

                    return Failure<Error, InvestmentDto>.Fail(DatabaseError.Create("InvestimentsUsecase.UpdateProduct"));
                }

                bool status = (bool)result.GetValue();

                _logger.Debug($"operação de atualização concluida. Status: {status}");

                return Success<Error, InvestmentDto>.Ok(product);
            }
            catch(Exception e)
            {
                _logger.Error($"houve um problema ao executar o método {nameof(UpdateProduct)}. Erro: {e.Message}", e);

                return Failure<Error, InvestmentDto>.Fail(Error.UnexpectedError("InvestimentsUsecase.UpdateProduct", e));
            }
        }

        public async Task<Either<Error, bool>> DeleteProduct(Guid id)
        {
            try
            {
                _logger.Debug("removendo entidade no banco de forma lógica");

                Expression<Func<InvestimentDocument, bool>> filter = a => a.Id.Equals(id) & a.IsActive;

                UpdateDefinition<InvestimentDocument> update = Builders<InvestimentDocument>.Update
                    .Set(a => a.IsActive, false);

                Either<Error, bool> result = await _repository.UpdateAsync(filter, update);

                if (result.IsLeft)
                {
                    _logger.Warning("houve um problema ao fazer a requisição no banco", result.GetValue());

                    return Failure<Error, bool>.Fail(DatabaseError.Create("InvestimentsUsecase.DeleteProduct"));
                }

                bool status = (bool)result.GetValue();

                _logger.Debug($"operação de atualização concluida. Status: {status}");

                return Success<Error, bool>.Ok(status);
            }
            catch(Exception e)
            {
                _logger.Error($"houve um problema ao executar o método {nameof(DeleteProduct)}. Erro: {e.Message}", e);

                return Failure<Error, bool>.Fail(Error.UnexpectedError("InvestimentsUsecase.DeleteProduct", e));
            }
        }
    }
}