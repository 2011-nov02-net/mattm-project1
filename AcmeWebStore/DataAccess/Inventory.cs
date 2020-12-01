using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Inventory
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Item { get; set; }
        public virtual Location Store { get; set; }
    }
}
