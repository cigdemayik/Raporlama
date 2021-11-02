using Raporlama.Business.Abstracts.Interfaces;
using Raporlama.Business.Dtos.ReportTypeDtos;
using Raporlama.DataAccess.Abstracts.Interfaces.Generic;
using Raporlama.Entities.Concrete;
using Raporlama.Helpers.Abstracts;
using Raporlama.DataAccess.Concrete.EfCore.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Raporlama.Helpers.ServiceHelpers.Concrete;
using Raporlama.DataAccess.Concrete.EFCore.Repositories.Generic;

namespace Raporlama.Business.Concrete
{
    public class ReportTypeManager : IReportTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceResponseHelper _serviceResponseHelper;

        public ReportTypeManager(IUnitOfWork unitOfWork,
            IServiceResponseHelper serviceResponseHelper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _serviceResponseHelper = serviceResponseHelper ?? throw new ArgumentNullException(nameof(serviceResponseHelper));
        }

        public Task<ServiceResponse<List<ReportTypeDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ReportType> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResponse<List<ReportTypeDto>>> IReportTypeService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<ReportTypeDto>> IReportTypeService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
