using System;
using System.Collections.Generic;

namespace ProjectOne.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Item { get; set; }
    }
}
