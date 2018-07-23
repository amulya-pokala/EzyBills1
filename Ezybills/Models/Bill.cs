using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ezybills.Models;

namespace EzyBills.Models
{
    public class Bill
    {
        [Required]
       
        public int BillVendorID { get; set; }

        [Required]

        public int BillCustomerID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillID { get; set; }

        [Display(Name ="Total")]
        public double Total_Bill { get; set; }


        [Display(Name ="Date")]
        public DateTime dateOfPurchase { get; set; }
    }
}