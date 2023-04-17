using KGD.Application.Contracts;
using KGD.Application.DTO;
using KGD.Domain.Entity;

namespace KGD.Application.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<List<ReportDTO>> GetReports(int? departmentId)
        {
            List<ReportDTO> reportDTOs = new List<ReportDTO>();
            var reports = departmentId != null
                ? await _reportRepository.GetReports(CancellationToken.None)
                : await _reportRepository.GetReports((int)departmentId, CancellationToken.None);
            foreach (var report in reports)
            {
                reportDTOs.Add(new ReportDTO
                {
                    Id = report.Id,
                    KGDCode = report.Department.Code,
                    Department = report.Department.Name,
                    NP_BIN = report.TaxPayer.Bin,
                    NPName = report.TaxPayer.Name,
                    CreatedDate = report.CreatedDate,
                    UpdatedDate = report.UpdatedDate,
                    Regulation = report.Regulation,
                    RegulationDate = report.RegulationDate,
                    PeriodNPFrom = report.PeriodNPFrom,
                    PeriodNPTo = report.PeriodNPTo,
                    ExceptedNPName = report.ExceptedTaxPayer.Name,
                    ExceptedNPBIN = report.ExceptedTaxPayer.Bin,
                    ServiceType = report.ServiceType.Name,
                    TotalSum = report.TotalSum,
                    OborotSumm = report.OborotSumm,
                    TaxSumm = report.TaxSumm,
                    ReportCreatedPeriod = report.ReportPeriod,
                    DepartmentId = report.Department.Id,
                    ExceptedNPId = report.ExceptedTaxPayerId,
                    NPId = report.TaxPayerId,
                    ServiceTypeId = report.ServiceType.Id,
                    UserId = report.UserId,
                    User = new UserDTO()
                    {
                        Name = report.User.Name,
                    },
                    PeriodNP = $"{report.PeriodNPFrom.ToString("dd/mm/yyyy")} - {report.PeriodNPTo.ToString("dd/mm/yyyy")}"
                });
            }
            return reportDTOs;
        }

        public async Task<ReportDTO> GetReportById(int id)
        {
            var report = await _reportRepository.GetReportById(id, CancellationToken.None);
            return new ReportDTO
            {
                Id = report.Id,
                KGDCode = report.Department.Code,
                Department = report.Department.Name,
                NP_BIN = report.TaxPayer.Bin,
                NPName = report.TaxPayer.Name,
                CreatedDate = report.CreatedDate,
                UpdatedDate = report.UpdatedDate,
                Regulation = report.Regulation,
                RegulationDate = report.RegulationDate,
                PeriodNPFrom = report.PeriodNPFrom,
                PeriodNPTo = report.PeriodNPTo,
                ExceptedNPName = report.ExceptedTaxPayer.Name,
                ExceptedNPBIN = report.ExceptedTaxPayer.Bin,
                ServiceType = report.ServiceType.Name,
                TotalSum = report.TotalSum,
                OborotSumm = report.OborotSumm,
                TaxSumm = report.TaxSumm,
                ReportCreatedPeriod = report.ReportPeriod,
                DepartmentId = report.Department.Id,
                ExceptedNPId = report.ExceptedTaxPayerId,
                NPId = report.TaxPayerId,
                ServiceTypeId = report.ServiceType.Id,
                UserId = report.UserId,
                User = new UserDTO()
                {
                    Name = report.User.Name,
                }
            };
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
        public async Task AddReport(ReportDTO reportDTO)
        {
            await _reportRepository.AddReport(new Domain.Entity.Report()
            {
                CreatedDate = DateTime.Now,
                DepartmentId = reportDTO.DepartmentId,
                ExceptedTaxPayerId = reportDTO.ExceptedNPId,
                OborotSumm = reportDTO.OborotSumm,
                Regulation = reportDTO.Regulation,
                PeriodNPFrom = reportDTO.PeriodNPFrom,
                PeriodNPTo = reportDTO.PeriodNPTo,
                TaxSumm = reportDTO.TaxSumm,
                TotalSum = reportDTO.TotalSum,
                UpdatedDate = DateTime.Now,
                ServiceTypeId = reportDTO.ServiceTypeId,
                TaxPayerId = reportDTO.NPId,
                RegulationDate = reportDTO.RegulationDate,
                ReportPeriod = reportDTO.ReportCreatedPeriod,
                UserId = reportDTO.UserId,
            });
        }
        public async Task EditReport(ReportDTO reportDTO)
        {
            await _reportRepository.EditReport(new Domain.Entity.Report()
            {
                CreatedDate = DateTime.Now,
                DepartmentId = reportDTO.DepartmentId,
                ExceptedTaxPayerId = reportDTO.ExceptedNPId,
                OborotSumm = reportDTO.OborotSumm,
                Regulation = reportDTO.Regulation,
                PeriodNPFrom = reportDTO.PeriodNPFrom,
                PeriodNPTo = reportDTO.PeriodNPTo,
                TaxSumm = reportDTO.TaxSumm,
                TotalSum = reportDTO.TotalSum,
                UpdatedDate = DateTime.Now,
                ServiceTypeId = reportDTO.ServiceTypeId,
                TaxPayerId = reportDTO.NPId,
                RegulationDate = reportDTO.RegulationDate,
                ReportPeriod = reportDTO.ReportCreatedPeriod,
                UserId = reportDTO.UserId,
            });
        }
        public async Task AddReportHistory(ReportHistoryDTO reportHistoryDTO)
        {
            await _reportRepository.AddReportHistory(new ReportHistory()
            {
                Action = reportHistoryDTO.Action,
                CreatedDateTime = reportHistoryDTO.CreatedDateTime,
                ReportId = reportHistoryDTO.ReportId,
                UserId = reportHistoryDTO.UserId
            });
        }
    }
}
