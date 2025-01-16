using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("Invoices")]
        public int InvoiceId { get; set; }

        public virtual Invoice Invoices { get; set; }

    }
}