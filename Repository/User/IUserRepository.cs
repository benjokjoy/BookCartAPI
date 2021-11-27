using Models.DTO;
using System.Threading.Tasks;

namespace Repository.User
{
   public interface IUserRepository
    {
        Task<UserResponseDto> GetUser(string userName,string password);
    }
}
