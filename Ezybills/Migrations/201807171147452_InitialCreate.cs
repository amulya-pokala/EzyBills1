namespace Ezybills.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerId = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        mailId = c.String(),
                        alias = c.String(),
                        password = c.String(nullable: false, maxLength: 100),
                        phoneNo = c.String(),
                    })
                .PrimaryKey(t => t.customerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
