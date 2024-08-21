using System.Text.Json.Serialization;
using Core.Enum;

namespace Core.Dto
{
    public record InvestmentDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nome")]   
        public required string Name { get; set; }

        [JsonPropertyName("tipo_investimento")]
        public InvestimentType Type { get; set; }

        [JsonPropertyName("data_compra")]
        public DateTime PurchaseDate { get; set; }

        [JsonPropertyName("data_vencimento")]
        public DateTime MaturityDate { get; set; }

        [JsonPropertyName("taxa_juros")]
        public decimal InterestRate { get; set; }

        [JsonPropertyName("preco_unitario")]
        public decimal Price { get; set; }

        [JsonPropertyName("criado_por")]
        public Guid CreatedBy { get; set; }
    }
}