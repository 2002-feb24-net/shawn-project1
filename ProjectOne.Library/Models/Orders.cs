using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.Models
{
    public partial class Orders
    {
        [Display(Name = "Order ID")]
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
        [Required]
        [Range(1, 30)]
        public int Quantity { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? Cart { get; set; }
        public string Store { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }

        public virtual Customers CustomerNavigation { get; set; }
    }
}
