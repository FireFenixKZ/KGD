using KGD.Application.DTO;

namespace KGD.Application.Contracts
{
    public interface IReportService
    {
        Task<List<ReportDTO>> GetReports();
        Task<List<RegionDTO>> GetRegions();
        Task<List<DepartmentDTO>> GetDepartments();
        Task<List<TaxPayerDTO>> GetTaxPayers();
        Task<List<ServiceTypeDTO>> GetServiceTypes();
        Task<ReportDTO> GetReportById(int id);
        Task AddReport(ReportDTO reportDTO);
    }
}
