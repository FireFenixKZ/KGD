using KGD.Application.Contracts;
using KGD.Domain.Entity;
using KGD.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KGD.Infrastructure.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;

        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartments(CancellationToken cancellationToken)
        {
            return await _context.Departments.ToListAsync(cancellationToken);
        }

        public async Task<List<Region>> GetRegions(CancellationToken cancellationToken)
        {
            return await _context.Regions.ToListAsync(cancellationToken);
        }

        public async Task<List<Report>> GetReports(CancellationToken cancellationToken)
        {
            return await _context.Reports
                .Include(s => s.TaxPayer)
                .Include(s => s.Department)
                .Include(s => s.ExceptedTaxPayer)
                .Include(s => s.ServiceType)
                .Include(s => s.User)
                .Include(s => s.Department)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Report>> GetReports(int departmentId, CancellationToken cancellationToken)
        {
            return await _context.Reports
                .Include(s => s.TaxPayer)
                .Include(s => s.Department)
                .Include(s => s.ExceptedTaxPayer)
                .Include(s => s.ServiceType)
                .Include(s => s.User)
                .Include(s => s.Department).Where(s => s.DepartmentId == departmentId)
                .ToListAsync(cancellationToken);
        }

        public async Task<Report> GetReportById(int id, CancellationToken cancellationToken)
        {
            return await _context.Reports
                .Include(s => s.TaxPayer)
                .Include(s => s.Department)
                .Include(s => s.ExceptedTaxPayer)
                .Include(s => s.ServiceType)
                .Include(s => s.User)
                .Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<List<ServiceType>> GetServiceTypes(CancellationToken cancellationToken)
        {
            return await _context.ServiceTypes.ToListAsync(cancellationToken);
        }

        public async Task<List<TaxPayer>> GetTaxPayers(CancellationToken cancellationToken)
        {
            return await _context.TaxPayers.ToListAsync(cancellationToken);
        }
        public async Task AddReport(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            await AddReportHistory(new ReportHistory()
            {
                Action = "Отчет создан",
                CreatedDateTime = DateTime.Now,
                ReportId = report.Id,
                UserId = report.UserId
            });
        }

        public async Task EditReport(Report report)
        {
            var model = await _context.Reports.FirstOrDefaultAsync(s => s.Id == report.Id, CancellationToken.None);
            if (model != null)
            {
                model.ReportPeriod = report.ReportPeriod;
                model.TaxPayerId = report.TaxPayerId;
                model.ExceptedTaxPayerId = report.ExceptedTaxPayerId;
                model.DepartmentId = report.DepartmentId;
                model.OborotSumm = report.OborotSumm;
                model.PeriodNPFrom = report.PeriodNPFrom;
                model.PeriodNPTo = report.PeriodNPTo;
                model.RegulationDate = report.RegulationDate;
                model.ServiceTypeId = report.ServiceTypeId;
                model.UserId = report.UserId;
                model.UpdatedDate = report.UpdatedDate;
                model.Regulation = report.Regulation;
                _context.Update(model);
                await _context.SaveChangesAsync();

                await AddReportHistory(new ReportHistory()
                {
                    Action = "Отчет изменен",
                    CreatedDateTime = DateTime.Now,
                    ReportId = report.Id,
                    UserId = report.UserId
                });
            }
        }
        public async Task AddReportHistory(ReportHistory reportHistory)
        {
            _context.ReportHistories.Add(reportHistory);
            await _context.SaveChangesAsync();
        }
    }
}
