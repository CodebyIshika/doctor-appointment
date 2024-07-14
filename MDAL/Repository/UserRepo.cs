using AutoMapper;
using MAEntities.Context;
using MAEntities.DTO;
using MAEntities.Entities;
using MDAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDAL.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly MedContext _context;
        private readonly IMapper _mapper;

        public UserRepo(MedContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task CreateUser(UserDto user)
        {
            var newUser = _mapper.Map<User>(user);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(int userId, UserDto user)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null)
            {
                throw new Exception($"User not found. Update failed.");
            }

            _mapper.Map(user, existingUser);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
