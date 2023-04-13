using KGD.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGD.Application.Contracts
{
    public interface IReportService
    {
        Task<List<ReportDTO>> GetReports();
        Task<List<RegionDTO>> GetRegions();
        Task<List<DepartmentDTO>> GetDepartments();
        Task<List<TaxPayerDTO>> GetTaxPayers();
        Task<List<ServiceTypeDTO>> GetServiceTypes();
    }
}
