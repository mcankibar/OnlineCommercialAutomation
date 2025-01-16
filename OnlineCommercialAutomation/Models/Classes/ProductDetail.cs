using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class ProductDetail
    {

        [Key, ForeignKey("Product")] 
        public int ProductId { get; set; } 

        public string Description { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }

        public Product Product { get; set; }
    }
}