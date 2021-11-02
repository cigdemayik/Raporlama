using Mapster;
using Raporlama.Business.Abstracts.Interfaces;
using Raporlama.Business.Dtos.UserDtos;
using Raporlama.DataAccess;
using Raporlama.DataAccess.Concrete.EFCore.Repositories.Generic;
using Raporlama.Entities.Concrete;
using Raporlama.Helpers.Abstracts;
using Raporlama.Helpers.ServiceHelpers.Concrete;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Raporlama.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceResponseHelper _serviceResponseHelper;

        public UserManager(IUnitOfWork unitOfWork,
            IServiceResponseHelper serviceResponseHelper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _serviceResponseHelper = serviceResponseHelper ?? throw new ArgumentNullException(nameof(serviceResponseHelper));
        }

        public Task<ServiceResponse<int>> Create(UserCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<User> GetById(int id)
        {
            var data = _unitOfWork.GetRepository<User>().GetByFilter(x => x.Id == id);
            if (data == null)
            {
                return _serviceResponseHelper.SetError<User>(data, "Product Bulunamadı", HttpStatusCode.NotFound);
            }
            else
            {
                return _serviceResponseHelper.SetSuccess(data, HttpStatusCode.OK);
            }
        }

        public ServiceResponse<UserDto> SignIn(UserLoginDto dto)
        {
            var data = _unitOfWork.GetRepository<User>().GetByFilter(x => x.Password == dto.Password && x.UserName == dto.UserName);
            var mappedData = data.Adapt<UserDto>();

            if (mappedData == null)
            {
                return _serviceResponseHelper.SetError<UserDto>(mappedData, "Bu Kullanıcı Adı ve Şifre Hatalı",
                    HttpStatusCode.NotFound);
            }
            return _serviceResponseHelper.SetSuccess(mappedData, HttpStatusCode.OK);
        }
    }
}
