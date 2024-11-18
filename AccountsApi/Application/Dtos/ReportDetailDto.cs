namespace AccountsApi.Application.Dtos
{
    public record ReportDetailDto
    {
        public string Date { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int MovementId { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal Amount { get; set; }
        public decimal AvailableBalance { get; set; }
        public string Detail { get; set; } = string.Empty;
    }
}
