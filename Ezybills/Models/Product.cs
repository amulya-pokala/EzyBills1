using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzyBills.Models
{
    public class Product
    {
        [Required]
        [ForeignKey("VendorID")]
        public int ItemVendorId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        public String ProductName { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        public String ProductCategory { get; set; }

        public String ProductDescription { get; set; }

        public String ProductQuantity { get; set; }


    }
}