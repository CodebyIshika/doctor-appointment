using MAEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLL.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int userId);
        Task CreateUser(UserDto user);
        Task UpdateUser(int userId, UserDto user);
        Task DeleteUser(int userId);
    }
}
