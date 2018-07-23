using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ezybills.Models
{
    public class EzybillsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EzybillsContext() : base("name=EzybillsContext")
        {
        }

        public System.Data.Entity.DbSet<EzyBills.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<EzyBills.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<EzyBills.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<EzyBills.Models.Bill> Bills { get; set; }

        public System.Data.Entity.DbSet<Ezybills.Models.Item> Items { get; set; }
    }
}
