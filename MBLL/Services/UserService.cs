using AutoMapper;
using MAEntities.DTO;
using MAEntities.Entities;
using MBLL.Interface;
using MDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepo.GetAllUsers();
            return users;
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }
            return user;
        }

        public async Task CreateUser(UserDto userDto)
        {
            await _userRepo.CreateUser(userDto);
        }

        public async Task UpdateUser(int userId, UserDto userDto)
        {
            await _userRepo.UpdateUser(userId, userDto);
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepo.DeleteUser(userId);
        }
    }
}
