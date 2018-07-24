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

        [Display(Name = "Vendor")]

        public int ItemVendorId { get; set; }
        public virtual Vendor Vendor { get; set; }



        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductID { get; set; }



        [Required]

        [Display(Name = "Product")]

        public String ProductName { get; set; }



        [Required]

        [Display(Name = "Price")]

        public double ProductPrice { get; set; }



        [Display(Name = "Category")]

        public String ProductCategory { get; set; }



        [Display(Name = "Description(if any)")]

        public String ProductDescription { get; set; }



        [Display(Name = "Quantity")]

        public int ProductQuantity { get; set; }




    }
}