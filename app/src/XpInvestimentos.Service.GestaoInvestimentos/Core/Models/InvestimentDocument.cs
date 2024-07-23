using Core.Enum;
using Core.Interfaces;

namespace Core.Models
{
    public class InvestimentDocument : MongoDocument
    {
        public required string Name { get; set; }

        public InvestimentType Type { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public decimal InterestRate { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }
    }
}