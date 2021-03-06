﻿using System;
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
        private List<OrderDetails> _details;
     
        public Order()
        {
            OrderContents = new Dictionary<Product, int>();
            Details = new List<OrderDetails>();


        }

        public List<OrderDetails> Details
        {
            get => _details;
            set
            {
                _details = value;
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

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
