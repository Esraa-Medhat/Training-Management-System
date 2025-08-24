using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training_Management_System.DAL.Models.Users;
using Training_Management_System.DAL.Presistance.Data;

namespace Training_Management_System.DAL.Presistance.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.AsNoTracking().ToList();
        }

        public User? GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByName(string name)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Name == name);
        }

        public int Add(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }

        public int Update(User user)
        {
            _dbContext.Users.Update(user);
            return _dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}

