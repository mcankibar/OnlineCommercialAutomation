using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int CategoryId { get; set; }
        public string ProductImageUrl { get; set; }
        public bool IsActive { get; set; }

        // ProductDetail için alanlar
        public string Description { get; set; }
    }
}