using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Models.ViewModels
{
    public class MenuVM
    {
        public IEnumerable<BurgerVM> Burgers { get; set; }
        public string Currency { get; set; }
    }
}
