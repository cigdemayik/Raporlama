using Raporlama.Business.Dtos.ReportTypeDtos;
using Raporlama.Helpers.ServiceHelpers.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raporlama.Business.Abstracts.Interfaces
{
    public interface IReportTypeService 
    {
        Task<ServiceResponse<ReportTypeDto>> GetById(int id);
        Task<ServiceResponse<List<ReportTypeDto>>> GetAll();
    }
}
