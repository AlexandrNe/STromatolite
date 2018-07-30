namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("sm.Orders", "OrderDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("sm.Orders", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
