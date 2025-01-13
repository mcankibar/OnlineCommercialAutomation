using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class SalesTransaction
    {
        [Key]
        public int Id { get; set; }

        //product

        //customer

        //personal

        
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice{ get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        [ForeignKey("Personal")]
        public int PersonalId { get; set; }

        public virtual Personal Personal { get; set; }


    }
}