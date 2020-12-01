using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Location Location { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
