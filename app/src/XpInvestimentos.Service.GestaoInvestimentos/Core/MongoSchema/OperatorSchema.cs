using Core.Interfaces;
using Core.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Core.MongoSchema
{
    public class OperatorSchema : IMongoSchema
    {
        public void Mapping()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(OperatorDocument)))
            {
                BsonClassMap.RegisterClassMap<OperatorDocument>(o =>
                {
                    o.MapMember(a => a.Id)
                        .SetElementName("operator_id")
                        .SetSerializer(new GuidSerializer())
                        .SetIdGenerator(GuidGenerator.Instance);

                    o.MapMember(a => a.FirstName)
                        .SetElementName("first_name");

                    o.MapMember(a => a.LastName)
                        .SetElementName("last_name");

                    o.MapMember(a => a.IsActive)
                        .SetElementName("is_active");

                    o.MapMember(a => a.CreatedBy)
                        .SetElementName("created_by");

                    o.MapMember(a => a.CreatedAt)
                        .SetElementName("created_at");

                    o.MapMember(a => a.UpdatedBy)
                        .SetElementName("updated_by");

                    o.MapMember(a => a.UpdatedAt)
                        .SetElementName("updated_at");

                    o.MapMember(a => a.Version)
                        .SetElementName("versao");
                });
            }
        }
    }
}