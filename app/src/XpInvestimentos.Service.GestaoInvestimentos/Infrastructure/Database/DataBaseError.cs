using Core.Errors;

namespace Infrastructure.Database
{
    public class MongoOperationError(string code, string description, Exception e) : Error(code, description, e)
    {
        public static MongoOperationError MongoException(string code, Exception e) => new(code, "error executing the operation in the database.", e);
    }
}