using Core.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Core.MongoSchema
{
    public class BsonClassMaps
    {
        public static void Register()
        {
            //MongoDocument
            if (!BsonClassMap.IsClassMapRegistered(typeof(MongoDocument)))
            {
                BsonClassMap.RegisterClassMap<MongoDocument>(doc =>
                {
                    doc.MapMember(a => a.Id)
                        .SetElementName("id")
                        .SetSerializer(new GuidSerializer())
                        .SetIdGenerator(GuidGenerator.Instance);

                    doc.MapMember(a => a.CreatedBy)
                        .SetElementName("criado_por");

                    doc.MapMember(a => a.CreatedAt)
                        .SetElementName("criado_em");

                    doc.MapMember(a => a.UpdatedBy)
                        .SetElementName("atualizado_por");

                    doc.MapMember(a => a.UpdatedAt)
                        .SetElementName("atualizado_em");

                    doc.MapMember(a => a.IsActive)
                        .SetElementName("ativo");

                    doc.MapMember(a => a.Version)
                        .SetElementName("versao");
                });
            }

            //Investiment
            if (!BsonClassMap.IsClassMapRegistered(typeof(InvestimentDocument)))
            {
                BsonClassMap.RegisterClassMap<InvestimentDocument>(doc =>
                {
                    doc.MapMember(a => a.Name)
                        .SetElementName("nome");

                    doc.MapMember(a => a.Type)
                        .SetElementName("tipo_investimento");

                    doc.MapMember(a => a.PurchaseDate)
                        .SetElementName("data_compra");

                    doc.MapMember(a => a.MaturityDate)
                        .SetElementName("data_vencimento");

                    doc.MapMember(a => a.InterestRate)
                        .SetElementName("taxa_juros");

                    doc.MapMember(a => a.Price)
                    .SetElementName("preco_unitario");
                });
            }

            //Transaction
            if (!BsonClassMap.IsClassMapRegistered(typeof(TransactionDocument)))
            {
                BsonClassMap.RegisterClassMap<TransactionDocument>(doc =>
                {
                    doc.MapMember(a => a.Amount)
                        .SetElementName("quantidade");

                    doc.MapMember(a => a.Type)
                        .SetElementName("tipo_transacao");

                    doc.MapMember(a => a.DateTransaction)
                        .SetElementName("data_transacao");

                    doc.MapMember(a => a.Product)
                        .SetElementName("produto");

                    doc.MapMember(a => a.Client)
                        .SetElementName("cliente");
                });
            }

            //Investor
            if (!BsonClassMap.IsClassMapRegistered(typeof(InvestorDocument)))
            {
                BsonClassMap.RegisterClassMap<InvestorDocument>(doc =>
                {
                    doc.MapMember(a => a.FirstName)
                        .SetElementName("nome");

                    doc.MapMember(a => a.LastName)
                        .SetElementName("sobrenome");

                    doc.MapMember(a => a.Email)
                        .SetElementName("email");

                    doc.MapMember(a => a.Profile)
                        .SetElementName("perfil");
                });
            }

            //Operator
            if (!BsonClassMap.IsClassMapRegistered(typeof(OperatorDocument)))
            {
                BsonClassMap.RegisterClassMap<OperatorDocument>(doc =>
                {
                    doc.MapMember(a => a.FirstName)
                        .SetElementName("nome");

                    doc.MapMember(a => a.LastName)
                        .SetElementName("sobrenome");
                });
            }    

            if (!BsonClassMap.IsClassMapRegistered(typeof(Investment)))
            {
                BsonClassMap.RegisterClassMap<Investment>(doc =>
                {
                    doc.MapMember(a => a.Id)
                        .SetElementName("id_produto");

                    doc.MapMember(a => a.Name)
                        .SetElementName("nome");

                    doc.MapMember(a => a.Price)
                        .SetElementName("preco");
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Client)))
            {
                BsonClassMap.RegisterClassMap<Client>(doc =>
                {
                    doc.MapMember(a => a.Id)
                        .SetElementName("id_cliente");

                    doc.MapMember(a => a.Name)
                        .SetElementName("nome");
                });
            }
        }        
    }
}