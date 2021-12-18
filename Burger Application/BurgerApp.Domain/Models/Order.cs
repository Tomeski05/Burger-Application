using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BurgerApp.Domain.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        //navigation property
        public virtual User User { get; set; }
        public virtual List<BurgerOrder> BurgerOrders { get; set; }

        //price for all burgers
        [NotMapped]
        public double Price
        {
            get
            {
                if(BurgerOrders != null)
                {
                    return BurgerOrders.Sum(x => x.Burger.Price) + 2;
                }
                return 0;
            }
        }

    }
}
