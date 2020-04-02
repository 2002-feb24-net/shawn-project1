using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}