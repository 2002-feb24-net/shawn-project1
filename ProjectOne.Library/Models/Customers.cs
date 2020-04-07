using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Must be letters only.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters long.")] 
        public string FirstName { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be numbers only.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Must be 10 digits long.")]
        public string PhoneNumber { get; set; }
        public string Store { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
