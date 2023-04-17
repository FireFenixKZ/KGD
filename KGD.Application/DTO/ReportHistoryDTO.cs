namespace KGD.Application.DTO
{
    public class ReportHistoryDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Action { get; set; }
        public int ReportId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
