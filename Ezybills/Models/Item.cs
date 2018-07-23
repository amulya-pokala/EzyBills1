using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ezybills.Models;
using EzyBills.Models;

namespace Ezybills.Models
{
    public class Item
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        public int ItemBillID { get; set; }
        public virtual Bill Bill { get; set; }
        public String ItemName { get; set; }

        [Display(Name = "Quantity")]
        public double QuantityPurchased { get; set; }
        [Display(Name = "Cost")]
        public double QuantityCost { get; set; }
    }
}