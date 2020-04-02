using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [DisplayName("First Name")]
        public string FirstName{ get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Preferred Location")]
        public string PreferredLocation { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}