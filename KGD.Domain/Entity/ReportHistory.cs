namespace KGD.Domain.Entity
{
    public class ReportHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Action { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
