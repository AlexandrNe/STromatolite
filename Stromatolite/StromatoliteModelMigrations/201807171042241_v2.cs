namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sm.Groups",
                c => new
                    {
                        GroupID = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        SEOurl = c.String(),
                        Active = c.Boolean(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            AddColumn("sm.Products", "Ord", c => c.Int(nullable: false));
            AddColumn("sm.Products", "Group_GroupID", c => c.Guid());
            CreateIndex("sm.Products", "Group_GroupID");
            AddForeignKey("sm.Products", "Group_GroupID", "sm.Groups", "GroupID");
            DropColumn("sm.Products", "Sort");
        }
        
        public override void Down()
        {
            AddColumn("sm.Products", "Sort", c => c.Int(nullable: false));
            DropForeignKey("sm.Products", "Group_GroupID", "sm.Groups");
            DropIndex("sm.Products", new[] { "Group_GroupID" });
            DropColumn("sm.Products", "Group_GroupID");
            DropColumn("sm.Products", "Ord");
            DropTable("sm.Groups");
        }
    }
}
