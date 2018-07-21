namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("sm.Pictures", "Title", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("sm.Pictures", "Title", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
