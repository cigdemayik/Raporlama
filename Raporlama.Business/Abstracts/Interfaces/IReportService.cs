using Raporlama.Business.Dtos.ReportDtos;
using Raporlama.Helpers.ServiceHelpers.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raporlama.Business.Abstracts.Interfaces
{
    public interface IReportService
    {
        Task<ServiceResponse<ReportDto>> GetById(int id);
        Task<ServiceResponse<List<ReportDto>>> GetAll();
        ServiceResponse<List<ReportDto>> GetByCompanyIdAndReportType(int companyId, int reportTypeId);
    }
}
