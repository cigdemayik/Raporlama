using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mapster;
using Raporlama.Business.Abstracts.Interfaces;
using Raporlama.Business.Dtos.ReportDtos;
using Raporlama.DataAccess;
using Raporlama.DataAccess.Abstracts.Interfaces.Generic;
using Raporlama.DataAccess.Concrete.EFCore.Repositories.Generic;
using Raporlama.Entities.Concrete;
using Raporlama.Helpers.Abstracts;
using Raporlama.Helpers.ServiceHelpers.Concrete;

namespace Raporlama.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceResponseHelper _serviceResponseHelper;

        public ReportManager(IUnitOfWork unitOfWork,
            IServiceResponseHelper serviceResponseHelper) 
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _serviceResponseHelper = serviceResponseHelper ?? throw new ArgumentNullException(nameof(serviceResponseHelper));
        }

        public Task<ServiceResponse<List<ReportDto>>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<List<ReportDto>> GetByCompanyIdAndReportType(int companyId, int reportTypeId)
        {
            try
            {
                var includes = new List<string>();
                includes.Add("ReportType");
                var data = _unitOfWork.GetRepository<Report>().GetAllByFilter(x => x.CompanyId == companyId && x.ReportTypeId == reportTypeId, includes).ToList();
                var mappedData = data.Adapt<List<ReportDto>>();

                if (mappedData.Count > 0)
                    return _serviceResponseHelper.SetSuccess<List<ReportDto>>(mappedData, HttpStatusCode.OK);
                return _serviceResponseHelper.SetError<List<ReportDto>>(null, "Şirketin bu tipte bir raporu yoktur.", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return _serviceResponseHelper.SetError<List<ReportDto>>(null, $"Sistemsel bir hata ile karşılaşıldı. {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        public ServiceResponse<Report> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResponse<ReportDto>> IReportService.GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
