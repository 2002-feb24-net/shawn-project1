using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class Order
    {
        public int ID { get; set; }               //ck?
        [DisplayName("Cart ID")]
        public int CartID { get; set; }           //ck?
        [DisplayName("Quantity Sold")]
        public int QuantitySold { get; set; }
        [DisplayName("Price Total")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceTotal { get; set; }
        [DisplayName("Store Location")]
        public string StoreLocation { get; set; }
        [DisplayName("Date And Time")]
        public DateTime DateAndTime { get; set; }
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }       //fk
        [DisplayName("Product ID")]
        public int ProductID { get; set; }        //fk
    }
}