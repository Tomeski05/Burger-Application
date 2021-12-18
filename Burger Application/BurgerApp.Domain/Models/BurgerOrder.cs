using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Domain.Models
{
    public class BurgerOrder : BaseEntity
    {
        public int OrderId { get; set; }
        public int BurgerId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Burger Burger { get; set; }
    }
}
