using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class Store
    {
        public int ID { get; set; }                         //pk
        [DisplayName("Inventory")]
        public string Inventory { get; set; }       
        public string City { get; set; }
        public string State { get; set; }
        [DisplayName("Total Sales Quantity")]
        public int TotalSalesQuantity { get; set; }     //fk?
        [DisplayName("Total Sales Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSalesAmount { get; set; }       //fk?
    }
}