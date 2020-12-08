using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWebStore.ViewModels
{
    public class OrderViewModel
    {
      
            public int Id;
            public CustomerViewModel Customer;
            public LocationViewModel Location;
            public Dictionary<ProductViewModel, int> OrderContents;

        public OrderViewModel()
        {
            OrderContents = new Dictionary<ProductViewModel, int>();
            Customer = new CustomerViewModel();
            Location = new LocationViewModel();


        }

        public int GetItemsSold()
        {
            return this.OrderContents.Values.Sum();
        }

        public decimal GetTotalPrice()
        {
            decimal total = new decimal();
            foreach(KeyValuePair<ProductViewModel, int> contents in this.OrderContents)
            {
                total += contents.Key.Price * contents.Value;
            }
            return total;
        }


      
        
    }
}
