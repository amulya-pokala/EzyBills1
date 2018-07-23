using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ezybills.Models;
namespace Ezybills.Models
{
    public class Item
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        public int BillId { get; set; }
        public String ItemName { get; set; }

        public double QuantityPurchased { get; set; }
        public double QuantityCost { get; set; }
    }
}