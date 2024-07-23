using Core.Enum;
using Core.Interfaces;

namespace Core.Models
{
    public class TransactionDocument : MongoDocument
    {
        public required Investment Product { get; set; }

        public required Client Client { get; set; }
        
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime DateTransaction { get; set; }
    }

    public class Investment
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class Client 
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}