using System.Linq.Expressions;
using MongoDB.Driver;

namespace Core.Interfaces
{
    public interface IMongoRepository
    {
        IEnumerable<TEntity> QueryAsync<TEntity>() where TEntity : MongoDocument;

        Task InsertAsync<TEntity>(TEntity entity, InsertOneOptions? options = null) where TEntity : MongoDocument;

        Task<bool> AtualizarAsync<TEntity>(Expression<Func<TEntity, bool>> filtro, TEntity entity, ReplaceOptions? options = null) where TEntity : MongoDocument;

        Task<bool> RemoverAsync<TEntity>(Expression<Func<TEntity, bool>> filtro) where TEntity : MongoDocument;
    }
}