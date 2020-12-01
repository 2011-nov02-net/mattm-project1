using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Product
    {
        public Product()
        {
            LocationStocks = new HashSet<LocationStock>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<LocationStock> LocationStocks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
