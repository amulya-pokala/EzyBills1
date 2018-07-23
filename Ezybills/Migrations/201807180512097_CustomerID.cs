namespace Ezybills.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EmailId", c => c.String());
            DropColumn("dbo.Customers", "mailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "mailId", c => c.String());
            DropColumn("dbo.Customers", "EmailId");
        }
    }
}
