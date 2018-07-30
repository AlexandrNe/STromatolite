namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sm.Orders",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        OrderNum = c.String(nullable: false, maxLength: 200),
                        OrderDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        PhoneNumber = c.String(maxLength: 50),
                        FullName = c.String(maxLength: 256),
                        IP = c.String(maxLength: 50),
                        Comment = c.String(),
                        Closed = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("sm.Orders");
        }
    }
}
