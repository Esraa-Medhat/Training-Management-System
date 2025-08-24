using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Users;

namespace Training_Management_System.DAL.Presistance.Repositories.Users
{
    public interface IUserRepository
    {
        User? GetById(int id);
        User? GetByName(string name);
        IEnumerable<User> GetAll();
        int Add(User user);
        int Update(User user);
        void Delete(User user);
    }
}
