using System.Linq.Expressions;
using Core.Interfaces;
using MongoDB.Driver;
using NLog;

namespace Infrastructure.Database.Repository
{
    public class MongoRepository(IMongoContext context, ILogger logger): IMongoRepository
    {
        private readonly IMongoContext _context = context;

        private readonly ILogger _logger = logger;

        public IEnumerable<TEntity> QueryAsync<TEntity>() where TEntity : MongoDocument
        {
            try
            {
                return _context.Collection<TEntity>().AsQueryable();
            }
            catch
            {
                _logger.Warn("Erro ao executar a operação no banco");

                throw;
            }
        }

        public async Task InsertAsync<TEntity>(TEntity entity, InsertOneOptions? options = null) where TEntity : MongoDocument
        {
            try
            {
                IndexKeysDefinition<TEntity> indexKey = Builders<TEntity>.IndexKeys.Ascending(entity => entity.Id);

                CreateIndexOptions indexOptions = new CreateIndexOptions
                {
                    Name = "entityIdKey",
                    Unique = true,
                    Version = 1
                };

                CreateIndexModel<TEntity> index = new CreateIndexModel<TEntity>(indexKey, indexOptions);

                _context.Collection<TEntity>().Indexes.CreateOne(index);

                await _context.Collection<TEntity>().InsertOneAsync(entity, options);
            }
            catch
            {
                _logger.Warn("Erro ao executar a operação no banco");

                throw;
            }
        }

        public async Task<bool> AtualizarAsync<TEntity>(Expression<Func<TEntity, bool>> filtro, TEntity entity, ReplaceOptions? options = null) where TEntity : MongoDocument
        {
            try
            {
                var teste = await _context.Collection<TEntity>().ReplaceOneAsync(filtro, entity, options);

                ReplaceOneResult resultado = await _context.Collection<TEntity>().ReplaceOneAsync(filtro, entity, options);

                return resultado.IsAcknowledged && resultado.ModifiedCount > 0;
            }
            catch
            {
                _logger.Warn("Erro ao executar a operação no banco");

                throw;
            }
        }

        public async Task<bool> RemoverAsync<TEntity>(Expression<Func<TEntity, bool>> filtro) where TEntity : MongoDocument
        {
            try
            {
                DeleteResult result = await _context.Collection<TEntity>().DeleteOneAsync(filtro);

                return result.IsAcknowledged && result.DeletedCount > 0;
            }
            catch
            {
                _logger.Warn("Erro ao executar a operação no banco");
                
                throw;
            }
        }
    }
}