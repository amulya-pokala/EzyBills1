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

        [Display(Name = "Vendor")]

        public int BillVendorID { get; set; }

        public virtual Vendor Vendor { get; set; }

        [Required]

        [Display(Name = "Customer")]

        public int BillCustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillID { get; set; }

        [Display(Name ="Total")]
        public double Total_Bill { get; set; }

        [Required]
        [Display(Name ="Date")]
        public DateTime dateOfPurchase { get; set; }
    }
}