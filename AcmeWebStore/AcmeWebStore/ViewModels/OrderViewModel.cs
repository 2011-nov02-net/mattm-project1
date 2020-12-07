using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWebStore.ViewModels
{
    public class OrderViewModel
    {
      
            public int Id;
            public int CustomerId;
            public int LocationId;
            public Dictionary<int, int> OrderContents;


            public void AddToOrder(int prodId, int quant, int available)
            {
                if (CheckStock(quant, available))
                {
                    OrderContents.Add(prodId, quant);
                }


            }

            public bool CheckStock(int requestQuant, int availableQuant)
            {
                return (requestQuant <= availableQuant);
            }
        
    }
}
