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

        public string State { get; set; }

        public string Country { get; set; }

        public Dictionary<Library.Model.Product, int> inventory { get; set; }

     
    }
}
