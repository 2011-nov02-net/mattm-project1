using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWebStore.ViewModels
{
    public class NewOrderViewModel
    {
        public NewOrderViewModel()
        {
            orderContents = new Dictionary<int, int>();
        }
        public Dictionary<int, int> orderContents { get; set; }
    }
}
