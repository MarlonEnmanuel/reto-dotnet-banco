namespace AccountsApi.Application.Dtos
{
    public class ReportQueryDto
    {
        public int? ClientId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
