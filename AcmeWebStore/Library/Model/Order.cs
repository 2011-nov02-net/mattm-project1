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
        private Dictionary<int, int> _orderContents;


        public void AddToOrder(int prodId, int quant, int available)
        {
            if(CheckStock(quant, available))
            {
                _orderContents.Add(prodId, quant);
            }

          
        }

        public bool CheckStock(int requestQuant, int availableQuant)
        {
            return (requestQuant <= availableQuant);
        }
    }
}
