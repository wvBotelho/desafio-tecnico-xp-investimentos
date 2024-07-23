using Core.Interfaces;

namespace Core.Models
{
    public class OperatorDocument : MongoDocument
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}