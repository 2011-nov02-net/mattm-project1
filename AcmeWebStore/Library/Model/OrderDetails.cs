using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class OrderDetails
    {
        private int _id;
        private int _orderId;
        private int _locationId;
        private int _productId;
        private int _quantity;


        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        public int OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
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

        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
            }
        }

   
    }
}
