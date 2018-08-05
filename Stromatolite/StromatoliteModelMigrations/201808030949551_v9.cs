namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sm.GeneralSettings",
                c => new
                    {
                        GeneralSettingID = c.Int(nullable: false, identity: true),
                        SettingName = c.String(nullable: false, maxLength: 200),
                        SettingValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GeneralSettingID);
            
            CreateTable(
                "sm.NotificationEmails",
                c => new
                    {
                        NotificationEmailID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationEmailID);
            
        }
        
        public override void Down()
        {
            DropTable("sm.NotificationEmails");
            DropTable("sm.GeneralSettings");
        }
    }
}
