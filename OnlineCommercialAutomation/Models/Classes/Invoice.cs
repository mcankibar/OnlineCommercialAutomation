using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string SerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TaxOffice { get; set; }


        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveredBy { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ReceivedBy { get; set; }

        public decimal TotalAmount { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}