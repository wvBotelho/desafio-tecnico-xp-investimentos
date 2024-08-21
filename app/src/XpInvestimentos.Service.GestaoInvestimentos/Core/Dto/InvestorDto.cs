using System.Text.Json.Serialization;
using Core.Enum;

namespace Core.Dto
{
    public class InvestorDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nome")]
        public required string FirstName { get; set; }

        [JsonPropertyName("sobrenome")]
        public required string LastName { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("perfil")]
        public ProfileType Profile { get; set; }
    }
}