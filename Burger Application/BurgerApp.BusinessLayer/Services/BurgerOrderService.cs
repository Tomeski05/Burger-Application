using BurgerApp.BusinessLayer.Interfaces;
using BurgerApp.DataAccess.Repositories;
using BurgerApp.Domain.Models;
using BurgerApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurgerApp.BusinessLayer.Services
{
    public class BurgerOrderService : IBurgerOrdersService
    {
        private readonly IRepository<Order> _orderRepository;

        public BurgerOrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderVM GetOrders()
        {
            var orders = _orderRepository.GetAll();

            var mappedOrders = orders.Select(x =>
                new OrderItemVM
                {

                }); 

            return null;
        }

    }
}
