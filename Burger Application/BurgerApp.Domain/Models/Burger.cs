using BurgerApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Domain.Models
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }
        public BurgerSize Size { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        // navigation prop
        public virtual List<BurgerOrder> BurgerOrders { get; set; }
    }
}
