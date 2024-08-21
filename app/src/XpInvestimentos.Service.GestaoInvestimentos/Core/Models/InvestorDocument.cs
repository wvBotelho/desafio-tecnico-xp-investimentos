using Core.Enum;

namespace Core.Models
{
    public record InvestorDocument : MongoDocument
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public ProfileType Profile { get; set; }
    }
}