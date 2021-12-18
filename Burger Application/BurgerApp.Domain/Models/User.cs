using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        //navigation properties
        public virtual List<Order> Orders { get; set; }
    }
}
