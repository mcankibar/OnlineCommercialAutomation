using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="At most you can use 30 characters")]
        public string Name { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Should give a surname")]
        public string Surname { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string City { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Mail { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}