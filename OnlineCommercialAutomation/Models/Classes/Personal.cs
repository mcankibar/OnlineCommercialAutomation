using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ImageUrl { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}