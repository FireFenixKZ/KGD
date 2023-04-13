using KGD.Application.Contracts;
using KGD.Application.DTO;

namespace KGD.Application.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<List<ReportDTO>> GetReports()
        {
            List<ReportDTO> reportDTOs = new List<ReportDTO>();
            var reports = await _reportRepository.GetReports(CancellationToken.None);
            foreach (var report in reports)
            {
                reportDTOs.Add(new ReportDTO
                {
                    Id = report.Id,
                    KGDCode = report.KGDCode,
                    Department = report.Department.Name,
                    NP_BIN = report.TaxPayer.Bin,
                    NPName = report.TaxPayer.Name,
                    CreatedDate = report.CreatedDate,
                    UpdatedDate = report.UpdatedDate,
                    Regulation = report.Regulation,
                    RegulationDate = report.RegulationDate,
                    PeriodNP = report.PeriodNP,
                    ExceptedNPName = report.ExceptedTaxPayer.Name,
                    ExceptedNPBIN = report.ExceptedTaxPayer.Bin,
                    ServiceType = report.ServiceType.Name,
                    TotalSum = report.TotalSum,
                    OborotSumm = report.OborotSumm,
                    TaxSumm = report.TaxSumm
                });
            }
            return reportDTOs;
        }
        public async Task<List<RegionDTO>> GetRegions()
        {
            var regionList = new List<RegionDTO>();
            var regions = await _reportRepository.GetRegions(CancellationToken.None);
            foreach (var region in regions)
            {
                regionList.Add(new RegionDTO
                {
                    Id = region.Id,
                    Name = region.Name,
                    ParentId = region.ParentId
                });
            }
            return regionList;
        }
        public async Task<List<DepartmentDTO>> GetDepartments()
        {
            var departmentList = new List<DepartmentDTO>();
            var departments = await _reportRepository.GetDepartments(CancellationToken.None);
            foreach (var department in departments)
            {
                departmentList.Add(new DepartmentDTO
                {
                    Id = department.Id,
                    Name = department.Name
                });
            }
            return departmentList;
        }
        public async Task<List<TaxPayerDTO>> GetTaxPayers()
        {
            var taxPayerList = new List<TaxPayerDTO>();
            var payers = await _reportRepository.GetTaxPayers(CancellationToken.None);
            foreach (var taxPayer in payers)
            {
                taxPayerList.Add(new TaxPayerDTO
                {
                    Id = taxPayer.Id,
                    Name = taxPayer.Name,
                    Bin = taxPayer.Bin
                });
            }
            return taxPayerList;
        }
        public async Task<List<ServiceTypeDTO>> GetServiceTypes()
        {
            var taxPayerList = new List<ServiceTypeDTO>();
            var payers = await _reportRepository.GetServiceTypes(CancellationToken.None);
            foreach (var serviceType in payers)
            {
                taxPayerList.Add(new ServiceTypeDTO
                {
                    Id = serviceType.Id,
                    Name = serviceType.Name
                });
            }
            return taxPayerList;
        }
    }
}
