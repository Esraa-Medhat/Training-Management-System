using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto? GetById(int id);
        string Create(UserDto userDto);
        int Update(UserDto userDto);
        bool Delete(int id);
    }
}
