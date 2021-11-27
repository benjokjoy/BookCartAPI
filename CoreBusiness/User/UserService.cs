using Models.DTO;
using Repository.User;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace CoreBusiness.User
{
    [ExcludeFromCodeCoverage]
    public  class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {

            this._userRepo = userRepo;
        }
        public async Task<UserResponseDto> GetUser(string userName, string password)
        {
            try
            {
                return await _userRepo.GetUser(userName, password);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
