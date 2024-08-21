using System.Linq.Expressions;
using Core.Contracts;
using Core.Errors;
using Core.Interfaces;
using Core.Models;
using MongoDB.Driver;
 
namespace Infrastructure.Database.Repository
{
    public class MongoRepository(IMongoContext context, ILoggerGenerator logger): IMongoRepository
    {
        private readonly IMongoContext _context = context;

        private readonly ILoggerGenerator _logger = logger;

        public Either<Error, IEnumerable<TEntity>> QueryAsync<TEntity>() where TEntity : MongoDocument
        {
            try
            {
                IEnumerable<TEntity> result = _context.Collection<TEntity>().AsQueryable();

                return Success<Error, IEnumerable<TEntity>>.Ok(result);
            }
            catch(Exception e)
            {
                _logger.Error("Erro ao executar a operação de busca no banco", e);

                return Failure<Error, IEnumerable<TEntity>>.Fail(MongoOperationError.MongoException("MongoRepository.QueryAsync", e));
            }
        }

        public async Task<Either<Error, IEnumerable<TEntity>>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> filter, FindOptions? options = null, SortDefinition<TEntity>? sort = null) where TEntity : MongoDocument
        {
            try
            {
                IEnumerable<TEntity> result = await _context
                    .Collection<TEntity>()
                    .Find(filter, options)
                    .Sort(sort)
                    .ToListAsync();

                return Success<Error, IEnumerable<TEntity>>.Ok(result);
            }
            catch(Exception e)
            {
                _logger.Error("Erro ao executar a operação de busca no banco", e);

                return Failure<Error, IEnumerable<TEntity>>.Fail(MongoOperationError.MongoException("MongoRepository.FindAsync", e));
            }
        }

        public async Task<Either<Error, bool>> InsertAsync<TEntity>(TEntity entity, InsertOneOptions? options = null) where TEntity : MongoDocument
        {
            try
            {
                IndexKeysDefinition<TEntity> indexKey = Builders<TEntity>.IndexKeys.Ascending(entity => entity.Id);

                CreateIndexOptions indexOptions = new()
                {
                    Name = "entityIdKey",
                    Unique = true,
                    Version = 1
                };

                CreateIndexModel<TEntity> index = new(indexKey, indexOptions);

                _context.Collection<TEntity>().Indexes.CreateOne(index);

                await _context.Collection<TEntity>().InsertOneAsync(entity, options);

                return Success<Error, bool>.Ok(true);
            }
            catch(Exception e)
            {
                _logger.Error("Erro ao executar a operação insert no banco", e);

                return Failure<Error, bool>.Fail(MongoOperationError.MongoException("MongoRepository.InsertAsync", e));
            }
        }

        public async Task<Either<Error, bool>> UpdateAsync<TEntity>(Expression<Func<TEntity, bool>> filter, UpdateDefinition<TEntity> update, UpdateOptions? options = null) where TEntity : MongoDocument
        {
            try
            {
                UpdateResult result = await _context.Collection<TEntity>().UpdateOneAsync(filter, update, options);

                return Success<Error, bool>.Ok(result.IsAcknowledged && result.ModifiedCount > 0);
            }
            catch(Exception e)
            {
                _logger.Error("Erro ao executar a operação no banco", e);

                return Failure<Error, bool>.Fail(MongoOperationError.MongoException("MongoRepository.UpdateAsync", e));
            }
        }

        public async Task<Either<Error, bool>> ReplaceAsync<TEntity>(Expression<Func<TEntity, bool>> filter, TEntity entity, ReplaceOptions? options = null) where TEntity : MongoDocument
        {
            try
            {
                ReplaceOneResult result = await _context.Collection<TEntity>().ReplaceOneAsync(filter, entity, options);

                return Success<Error, bool>.Ok(result.IsAcknowledged && result.ModifiedCount > 0);
            }
            catch(Exception e)
            {
                _logger.Error("Erro ao executar a operação no banco", e);

                return Failure<Error, bool>.Fail(MongoOperationError.MongoException("MongoRepository.AtualizarAsync", e));
            }
        }

        public async Task<Either<Error, bool>> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : MongoDocument
        {
            try
            {
                DeleteResult result = await _context.Collection<TEntity>().DeleteOneAsync(filter);

                return Success<Error, bool>.Ok(result.IsAcknowledged && result.DeletedCount > 0);
            }
            catch(Exception e)
            {
                _logger.Error("Erro ao executar a operação no banco", e);

                return Failure<Error, bool>.Fail(MongoOperationError.MongoException("MongoRepository.RemoverAsync", e));
            }
        }
    }
}