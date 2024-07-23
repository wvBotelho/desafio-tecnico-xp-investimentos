using Core.Interfaces;
using Core.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Core.MongoSchema
{
    public class InvestorSchema : IMongoSchema
    {
        public void Mapping()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(InvestorDocument)))
            {
                BsonClassMap.RegisterClassMap<InvestorDocument>(investor =>
                {
                    investor.MapMember(a => a.Id)
                        .SetElementName("investor_id")
                        .SetSerializer(new GuidSerializer())
                        .SetIdGenerator(GuidGenerator.Instance);

                    investor.MapMember(a => a.FirstName)
                        .SetElementName("first_name");

                    investor.MapMember(a => a.LastName)
                        .SetElementName("last_name");

                    investor.MapMember(a => a.Email)
                        .SetElementName("email");

                    investor.MapMember(a => a.Profile)
                        .SetElementName("profile");

                    investor.MapMember(a => a.IsActive)
                        .SetElementName("is_active");

                    investor.MapMember(a => a.CreatedBy)
                        .SetElementName("created_by");

                    investor.MapMember(a => a.CreatedAt)
                        .SetElementName("created_at");

                    investor.MapMember(a => a.UpdatedBy)
                        .SetElementName("updated_by");

                    investor.MapMember(a => a.UpdatedAt)
                        .SetElementName("updated_at");

                    investor.MapMember(a => a.Version)
                        .SetElementName("versao");
                });
            }
        }
    }
}