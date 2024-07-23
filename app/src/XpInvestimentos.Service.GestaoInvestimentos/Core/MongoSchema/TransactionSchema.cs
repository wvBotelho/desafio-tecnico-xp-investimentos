using System.Diagnostics.CodeAnalysis;
using Core.Interfaces;
using Core.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Core.MongoSchema
{
    [ExcludeFromCodeCoverage]
    public class TransactionSchema : IMongoSchema
    {
        public void Mapping()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TransactionDocument)))
            {
                BsonClassMap.RegisterClassMap<TransactionDocument>(transaction =>
                {
                    transaction.MapMember(a => a.Id)
                        .SetElementName("transaction_id")
                        .SetSerializer(new GuidSerializer())
                        .SetIdGenerator(GuidGenerator.Instance);

                    transaction.MapMember(a => a.Amount)
                        .SetElementName("amount");

                    transaction.MapMember(a => a.Type)
                        .SetElementName("type");

                    transaction.MapMember(a => a.DateTransaction)
                        .SetElementName("date_transaction");

                    transaction.MapMember(a => a.Product)
                        .SetElementName("product");

                    transaction.MapMember(a => a.Product.Id)
                        .SetElementName("product_id");

                    transaction.MapMember(a => a.Product.Name)
                    .SetElementName("name");

                    transaction.MapMember(a => a.Product.Price)
                        .SetElementName("price");

                    transaction.MapMember(a => a.Client)
                        .SetElementName("client");

                    transaction.MapMember(a => a.Client.Id)
                        .SetElementName("client_id");

                    transaction.MapMember(a => a.Client.Name)
                        .SetElementName("name");

                    transaction.MapMember(a => a.CreatedBy)
                        .SetElementName("created_by")
                        .SetIgnoreIfNull(true);

                    transaction.MapMember(a => a.CreatedAt)
                        .SetElementName("created_at")
                        .SetIgnoreIfNull(true);

                    transaction.MapMember(a => a.UpdatedBy)
                        .SetElementName("updated_by")
                        .SetIgnoreIfNull(true);

                    transaction.MapMember(a => a.UpdatedAt)
                        .SetElementName("updated_at")
                        .SetIgnoreIfNull(true);

                    transaction.MapMember(a => a.Version)
                        .SetElementName("versao");
                });
            }
        }
    }
}

