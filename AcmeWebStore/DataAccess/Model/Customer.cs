using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? FavoriteStore { get; set; }

        public virtual Location FavoriteStoreNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
