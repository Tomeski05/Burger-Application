using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Models.ViewModels
{
    public class OrderVM
    {
        public IEnumerable<OrderItemVM> Orders { get; set; }
        public int OrderCount { get; set; }
        public string LastBurger { get; set; }
        public string MostPopularBurger { get; set; }
        public string NameOfFirstCustomer { get; set; }
        public string Currency { get; set; }
    }
}
