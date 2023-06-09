﻿using KGD.Application.DTO;

namespace KGD.Application.Contracts
{
    public interface IReportService
    {
        Task<List<ReportDTO>> GetReports(int? departmnetId = default);
        Task<List<RegionDTO>> GetRegions();
        Task<List<DepartmentDTO>> GetDepartments();
        Task<List<TaxPayerDTO>> GetTaxPayers();
        Task<List<ServiceTypeDTO>> GetServiceTypes();
        Task<ReportDTO> GetReportById(int id);
        Task AddReport(ReportDTO reportDTO);
        Task AddReportHistory(ReportHistoryDTO reportHistoryDTO);
        Task EditReport(ReportDTO reportDTO);
        Task<List<ReportHistoryDTO>> GetReportHistory(int reportId);
    }
}
