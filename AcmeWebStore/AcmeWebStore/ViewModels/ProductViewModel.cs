using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcmeWebStore.ViewModels
{
    public class ProductViewModel
    {
        public string Name;

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price;

    }
}
