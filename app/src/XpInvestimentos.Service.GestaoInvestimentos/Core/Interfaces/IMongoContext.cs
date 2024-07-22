using MongoDB.Driver;

namespace Core.Interfaces
{
    public interface IMongoContext
    {
        IMongoCollection<TEntity> Collection<TEntity>() where TEntity : MongoDocument;
    }
}