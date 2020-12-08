using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcmeWebStore.ViewModels
{
    public class OrderViewModel
    {
      
            

        public OrderViewModel()
        {
            OrderContents = new Dictionary<ProductViewModel, int>();
            Customer = new CustomerViewModel();
            Location = new LocationViewModel();
        }
        public int Id;
        public CustomerViewModel Customer { get; set; }
        public LocationViewModel Location { get; set; }
        public Dictionary<ProductViewModel, int> OrderContents { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total { get; set; }

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
