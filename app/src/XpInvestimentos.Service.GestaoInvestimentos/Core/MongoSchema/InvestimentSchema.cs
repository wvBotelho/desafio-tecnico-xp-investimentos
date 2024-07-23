using Core.Interfaces;
using Core.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Core.MongoSchema
{
    public class InvestimentSchema : IMongoSchema
    {
        public void Mapping()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(InvestimentDocument)))
            {
                BsonClassMap.RegisterClassMap<InvestimentDocument>(investiment =>
                {
                    investiment.MapMember(a => a.Id)
                        .SetElementName("investiment_id")
                        .SetSerializer(new GuidSerializer())
                        .SetIdGenerator(GuidGenerator.Instance);

                    investiment.MapMember(a => a.Name)
                        .SetElementName("name");

                    investiment.MapMember(a => a.Type)
                        .SetElementName("type");

                    investiment.MapMember(a => a.PurchaseDate)
                        .SetElementName("purchase_date");

                    investiment.MapMember(a => a.MaturityDate)
                        .SetElementName("maturity_date");

                    investiment.MapMember(a => a.InterestRate)
                        .SetElementName("interest_rate");

                    investiment.MapMember(a => a.Price)
                    .SetElementName("price");

                    investiment.MapMember(a => a.IsActive)
                        .SetElementName("is_active");

                    investiment.MapMember(a => a.CreatedBy)
                        .SetElementName("created_by");

                    investiment.MapMember(a => a.CreatedAt)
                        .SetElementName("created_at");

                    investiment.MapMember(a => a.UpdatedBy)
                        .SetElementName("updated_by");

                    investiment.MapMember(a => a.UpdatedAt)
                        .SetElementName("updated_at");

                    investiment.MapMember(a => a.Version)
                        .SetElementName("versao");
                });
            }
        }
    }
}