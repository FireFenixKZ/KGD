using KGD.Domain.Entity;

namespace KGD.Application.Contracts
{
    public interface IReportRepository
    {
        Task<List<Department>> GetDepartments(CancellationToken cancellationToken);
        Task<List<Report>> GetReports(CancellationToken cancellationToken);
        Task<List<Report>> GetReports(int departmentId, CancellationToken cancellationToken);
        Task<List<TaxPayer>> GetTaxPayers(CancellationToken cancellationToken);
        Task<List<Region>> GetRegions(CancellationToken cancellationToken);
        Task<List<ServiceType>> GetServiceTypes(CancellationToken cancellationToken);
        Task<Report> GetReportById(int id, CancellationToken cancellationToken);
        Task AddReport(Report report);
        Task AddReportHistory(ReportHistory reportHistory);
        Task EditReport(Report report);
        Task<List<ReportHistory>> GetReportHistory(int id);
    }
}
