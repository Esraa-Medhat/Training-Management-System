using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Users;
using Training_Management_System.DAL.Presistance.Repositories.Users;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.UserService
{
   

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetAll();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }

        public UserDto? GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }


        public bool Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            _userRepository.Delete(user);
            return true;
        }

    
        public int Update(UserDto userDto)
        {
            var existingUser = _userRepository.GetById(userDto.Id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found.");

            existingUser.Name = userDto.Name;
            existingUser.Email = userDto.Email;
            existingUser.Role = userDto.Role;

            return _userRepository.Update(existingUser);
        }
        public string? Create(UserDto userDto)
        {
            var existingUser = _userRepository.GetAll()
                .FirstOrDefault(u => u.Name == userDto.Name || u.Email == userDto.Email);

            if (existingUser != null)
                return "A user with this Name or Email already exists.";

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Role = userDto.Role
            };

            _userRepository.Add(user);
            return null;
        }
    }
}
