using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurgerApp.DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly BurgerContext _context;

        public UserRepository(BurgerContext burgerContext)
        {
            _context = burgerContext;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public List<User> GetByFilter(Func<User, bool> filter)
        {
            return _context.Users.Where(filter).ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public int Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Remove(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                _context.Users.Remove(user);
            }
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == entity.Id);
            if(user != null)
            {
                user.Address = entity.Address;
                user.LastName = entity.LastName;
                user.FirstName = entity.FirstName;
                user.Phone = entity.Phone;
                if(entity.Orders != null)
                {
                    user.Orders = entity.Orders;
                }
            }
            _context.SaveChanges();
        }
    }
}
