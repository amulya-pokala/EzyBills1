using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzyBills.Models
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string VendorUsername { get; set;}

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        private String VendorPassword;


        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public String SetVendorPassword
        {
            get
            {
                return VendorPassword;
            }
            set
            {
                VendorPassword = value;
            }
        }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String VendorEmail { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "PhoneNo")]
        public string VendorPhone { get; set; }

        [Required]
        public String Location { get; set; }


        [Required]
        public String StoreName { get; set; }

    }
}