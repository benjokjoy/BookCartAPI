using Models.DTO;
using System.Threading.Tasks;

namespace CoreBusiness.User
{
   public interface IUserService
    {
        Task<UserResponseDto> GetUser(string userName, string password);
    }
}
