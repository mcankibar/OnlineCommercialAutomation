using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Department
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        public bool isActive { get; set ; } = true;

        public ICollection<Personal> Personals { get; set; }


    }
}