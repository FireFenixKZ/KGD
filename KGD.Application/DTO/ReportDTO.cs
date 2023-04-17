namespace KGD.Application.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public string KGDCode { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int NPId { get; set; }
        public string NP_BIN { get; set; }
        public string NPName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Regulation { get; set; }
        public string PeriodNP { get; set; }
        public DateTime RegulationDate { get; set; }
        public DateTime PeriodNPFrom { get; set; }
        public DateTime PeriodNPTo { get; set; }
        public int ExceptedNPId { get; set; }
        public string ExceptedNPName { get; set; }
        public string ExceptedNPBIN { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public decimal TotalSum { get; set; }
        public decimal OborotSumm { get; set; }
        public decimal TaxSumm { get; set; }
        public DateTime ReportCreatedPeriod { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }

    }
}
