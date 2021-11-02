using Raporlama.Business.Dtos.UserDtos;
using Raporlama.Entities.Concrete;
using Raporlama.Helpers.ServiceHelpers.Concrete;
using System.Threading.Tasks;

namespace Raporlama.Business.Abstracts.Interfaces
{
    public interface IUserService
    {
        ServiceResponse<User> GetById(int id);
        ServiceResponse<UserDto> SignIn(UserLoginDto dto);
        Task<ServiceResponse<int>> Create(UserCreateDto dto);
    }
}
