namespace KGD.Application.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public string KGDCode { get; set; }
        public string Department { get; set; }
        public string NP_BIN { get; set; }
        public string NPName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public string Regulation { get; set; }
        public DateTime RegulationDate { get; set; }
        public string PeriodNP { get; set; }
        public string ExceptedNPName { get; set; }
        public string ExceptedNPBIN { get; set; }
        public string ServiceType { get; set; }
        public decimal TotalSum { get; set; }
        public decimal OborotSumm { get; set; }
        public decimal TaxSumm { get; set;}

    }
}
