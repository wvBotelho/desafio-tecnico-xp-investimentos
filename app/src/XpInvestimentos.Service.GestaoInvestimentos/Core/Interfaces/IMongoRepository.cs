using System.Linq.Expressions;
using Core.Contracts;
using Core.Errors;
using Core.Models;
using MongoDB.Driver;

namespace Core.Interfaces
{
    public interface IMongoRepository
    {
        Either<Error, IEnumerable<TEntity>> QueryAsync<TEntity>() where TEntity : MongoDocument;

        Task<Either<Error, IEnumerable<TEntity>>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> filter, FindOptions? options = null, SortDefinition<TEntity>? sort = null) where TEntity : MongoDocument;

        Task<Either<Error, bool>> InsertAsync<TEntity>(TEntity entity, InsertOneOptions? options = null) where TEntity : MongoDocument;

        Task<Either<Error, bool>> UpdateAsync<TEntity>(Expression<Func<TEntity, bool>> filter, UpdateDefinition<TEntity> update, UpdateOptions? options = null) where TEntity : MongoDocument;

        Task<Either<Error, bool>> ReplaceAsync<TEntity>(Expression<Func<TEntity, bool>> filtro, TEntity entity, ReplaceOptions? options = null) where TEntity : MongoDocument;

        Task<Either<Error, bool>> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> filtro) where TEntity : MongoDocument;
    }
}