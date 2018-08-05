namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sm.ErrorLogs",
                c => new
                    {
                        ErrorLogID = c.Guid(nullable: false),
                        ErrDate = c.DateTime(nullable: false),
                        ErrDescription = c.String(),
                    })
                .PrimaryKey(t => t.ErrorLogID);
            
        }
        
        public override void Down()
        {
            DropTable("sm.ErrorLogs");
        }
    }
}
