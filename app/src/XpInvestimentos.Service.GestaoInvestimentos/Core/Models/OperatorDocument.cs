namespace Core.Models
{
    public record OperatorDocument : MongoDocument
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}