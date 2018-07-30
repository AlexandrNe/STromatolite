namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("sm.Orders", "OrderNum", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("sm.Orders", "OrderNum", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
