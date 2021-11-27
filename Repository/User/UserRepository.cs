using Models.DTO;
using Repository.Generic;
using System;
using System.Threading.Tasks;
using Entities = Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.User
{
    public class UserRepository : GenericRepository<Entities.User>, IUserRepository
    {
        public UserRepository(BookCartDBContext context) : base(context)
        {

        }
        public async Task<UserResponseDto> GetUser(string userName, string password)
        {
            try
            {
                var userData = await _context.Users.Where(i => i.UserName == userName && i.Password == password).FirstOrDefaultAsync();
                if (userData == null)
                {
                    return null;
                }
                return new UserResponseDto { Id = userData.Id, Role = userData.Role, UserName = userData.UserName };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
