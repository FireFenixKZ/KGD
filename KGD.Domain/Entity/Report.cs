﻿using System.ComponentModel.DataAnnotations;

namespace KGD.Domain.Entity
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string KGDCode { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int TaxPayerId { get; set; }
        public TaxPayer TaxPayer { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Regulation { get; set; }
        public DateTime RegulationDate { get; set; }
        public string PeriodNP { get; set; }
        public int ExceptedTaxPayerId { get; set; }
        public TaxPayer ExceptedTaxPayer { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public decimal TotalSum { get; set; }
        public decimal OborotSumm { get; set; }
        public decimal TaxSumm { get; set; }
    }
}
