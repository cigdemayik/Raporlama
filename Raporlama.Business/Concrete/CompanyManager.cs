using Raporlama.Business.Abstracts.Interfaces;
using Raporlama.Business.Dtos.CompanyDtos;
using Raporlama.DataAccess;
using Raporlama.DataAccess.Concrete.EFCore.Repositories.Generic;
using Raporlama.Entities.Concrete;
using Raporlama.Helpers.Abstracts;
using Raporlama.Helpers.ServiceHelpers.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raporlama.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceResponseHelper _serviceResponseHelper;

        public CompanyManager(IUnitOfWork unitOfWork,
            IServiceResponseHelper serviceResponseHelper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _serviceResponseHelper = serviceResponseHelper ?? throw new ArgumentNullException(nameof(serviceResponseHelper));
        }
    }
}
