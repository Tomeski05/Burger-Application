using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurgerApp.DataAccess.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly BurgerContext _context;
        public OrderRepository(BurgerContext context)
        {
            _context = context;
        }

        public BurgerContext BurgerContext { get; }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetByFilter(Func<Order, bool> filter)
        {
            return _context.Orders.Where(filter).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Remove(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if(order != null)
            {
                _context.Orders.Remove(order);
            }
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
