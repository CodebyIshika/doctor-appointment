using MAEntities.DTO;
using MAEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDAL.Interface
{
    public interface IUserRepo
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int userId);
        Task CreateUser(UserDto user);
        Task UpdateUser(int userId, UserDto user);
        Task DeleteUser(int userId);
    }
}
