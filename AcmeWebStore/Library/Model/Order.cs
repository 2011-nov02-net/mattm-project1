using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Order
    {
        private int _id;
        private int _customerId;
        private int _locationId;
        private Dictionary<Product, int> _orderContents;
        public Order()
        {
            orderContents = new Dictionary<Product, int>();
        }

        public Dictionary<Product, int> orderContents { get; set; }
        public Dictionary<Product, int> OrderContents
        {
            get => _orderContents;
            set
            {
               
                _orderContents = value;
            }
        }

        public int CustomerId
        {
            get => _customerId;
            set
            {
                _customerId = value;
            }
        }
        
        public int LocationId
        {
            get => _locationId;
            set
            {
                _locationId = value;
            }
        }

       
    }
}
