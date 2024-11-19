using System.Text.Json.Serialization;

namespace AccountsApi.Application.Dtos
{
    public record ReportDetailDto
    {
        [JsonPropertyName("Fecha")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("Cliente")]
        public string ClientName { get; set; } = string.Empty;

        [JsonPropertyName("Número cuenta")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonPropertyName("Tipo")]
        public string AccountType { get; set; } = string.Empty;

        [JsonPropertyName("Estado")]
        public bool Status { get; set; }

        [JsonPropertyName("Número movimiento")]
        public int MovementId { get; set; }

        [JsonPropertyName("Saldo inicial")]
        public decimal InitialBalance { get; set; }

        [JsonPropertyName("Movimiento")]
        public decimal Amount { get; set; }

        [JsonPropertyName("Saldo disponible")]
        public decimal AvailableBalance { get; set; }

        [JsonPropertyName("Detalle movimiento")]
        public string Detail { get; set; } = string.Empty;
    }
}
