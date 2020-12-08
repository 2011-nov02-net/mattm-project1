using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcmeWebStore.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
           Orders = new List<OrderViewModel>();
        }
        // the HTML/tag helpers like "DisplayNameFor"
        // will use this instead of the property's name
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
      
        public List<OrderViewModel> Orders { get; set; }
    
    }
}