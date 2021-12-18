using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurgerApp.DataAccess.Repositories
{
    public class BurgerRepository : IRepository<Burger>
    {
        private readonly BurgerContext _context;

        public BurgerRepository(BurgerContext burgerContext)
        {
            _context = burgerContext;
        }

        public List<Burger> GetAll()
        {
            return _context.Burgers.ToList();
        }

        public List<Burger> GetByFilter(Func<Burger, bool> filter)
        {
            return _context.Burgers.Where(filter).ToList();
        }

        public Burger GetById(int id)
        {
            return _context.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Burger entity)
        {
            _context.Burgers.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Remove(int id)
        {
            var burger = _context.Burgers.FirstOrDefault(x => x.Id == id);
            if(burger != null)
            {
                _context.Burgers.Remove(burger);
            }
            _context.SaveChanges();
        }

        public void Update(Burger entity)
        {
            _context.Burgers.Update(entity);
            _context.SaveChanges();
        }
    }
}
