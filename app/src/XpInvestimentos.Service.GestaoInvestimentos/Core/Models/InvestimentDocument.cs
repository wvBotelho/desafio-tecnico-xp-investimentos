using Core.CustomAttributes;
using Core.Enum;

namespace Core.Models
{
    [CollectionName("produto_investimento")]
    public record InvestimentDocument : MongoDocument
    {
        public required string Name { get; set; }

        public InvestimentType Type { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public decimal InterestRate { get; set; }

        public decimal Price { get; set; }
    }
}