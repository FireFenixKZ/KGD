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
            return await _context.Reports.Include(s => s.TaxPayer).Include(s => s.Department).Include(s => s.ExceptedTaxPayer).Include(s => s.ServiceType).ToListAsync(cancellationToken);
        }

        public async Task<Report> GetReportById(int id, CancellationToken cancellationToken)
        {
            return await _context.Reports.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
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
        }
    }
}
