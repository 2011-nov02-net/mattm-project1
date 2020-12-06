using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcmeWebStore.ViewModels
{
    public class LocationViewModel
    {
        // the HTML/tag helpers like "DisplayNameFor"
        // will use this instead of the property's name
        [Display(Name = "City")]
        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public Dictionary<ProductViewModel, int> Inventory { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double? Score { get; set; }
    }
}
