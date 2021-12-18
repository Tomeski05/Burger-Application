 using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Models.ViewModels
{
    public class OrderItemVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Price { get; set; }
        public IEnumerable<BurgerVM> Burgers { get; set; }
    }
}
