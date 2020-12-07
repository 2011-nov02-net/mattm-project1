using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcmeWebStore.ViewModels
{
    public class CustomerViewModel
    {
        // the HTML/tag helpers like "DisplayNameFor"
        // will use this instead of the property's name
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        //[Required]
        //public string address { get; set; }
        //[Required]
        //public string city { get; set; }
        //[Required]
        //public string state { get; set; }
        //[Required]
        //public string country { get; set; }

    
    }
}