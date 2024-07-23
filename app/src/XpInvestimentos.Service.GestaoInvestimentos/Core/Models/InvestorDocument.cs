using Core.Enum;
using Core.Interfaces;

namespace Core.Models
{
    public class InvestorDocument : MongoDocument
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public ProfileType Profile { get; set; }

        public bool IsActive { get; set; }
    }
}