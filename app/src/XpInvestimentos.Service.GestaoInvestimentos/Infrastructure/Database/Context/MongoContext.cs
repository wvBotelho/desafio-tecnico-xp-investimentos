using System.Diagnostics.CodeAnalysis;
using Core.CustomAttributes;
using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Infrastructure.Database.Context
{
    [ExcludeFromCodeCoverage]
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _dataBase;

        private readonly MongoConnection _connection;

        private readonly ILoggerGenerator _logger;

        public MongoContext(IOptions<MongoConnection> options, ILoggerGenerator logger)
        {
            try
            {
                _connection = options.Value;

                _logger = logger;

                InitializeGuidRepresentation();

                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(_connection.ConnectionString));

                if (_connection.IsSSL)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

                MongoClient client = new(settings);

                _dataBase = client.GetDatabase(_connection.Database);
            }
            catch (Exception e)
            {
                _logger!.Error($"Não foi possível conectar com o servidor. Erro: {e.Message}", e);

                throw;
            }
            
        }

        public IMongoCollection<TEntity> Collection<TEntity>() where TEntity : MongoDocument
        {
            return _dataBase.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        }

        private string GetCollectionName(Type type)
        {
            CollectionNameAttribute tableNameAttribute = (CollectionNameAttribute)Attribute.GetCustomAttribute(type, typeof(CollectionNameAttribute));

            if (tableNameAttribute is null)
                return type.Name.ToLower();

            return tableNameAttribute.TableName;
        }

        private void InitializeGuidRepresentation()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        }
    }
}