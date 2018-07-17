namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("sm.Products", "Group_GroupID", "sm.Groups");
            DropIndex("sm.Products", new[] { "Group_GroupID" });
            RenameColumn(table: "sm.Products", name: "Group_GroupID", newName: "GroupID");
            CreateTable(
                "sm.GalCategories",
                c => new
                    {
                        GalCategoryID = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        ProdGal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GalCategoryID);
            
            CreateTable(
                "sm.Galleries",
                c => new
                    {
                        GalleryID = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Abstarct = c.String(),
                        GalCategoryID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryID)
                .ForeignKey("sm.GalCategories", t => t.GalCategoryID, cascadeDelete: true)
                .Index(t => t.GalCategoryID);
            
            CreateTable(
                "sm.Pictures",
                c => new
                    {
                        PictureID = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        PicUrl = c.String(nullable: false),
                        GalleryID = c.Guid(nullable: false),
                        Ord = c.Int(),
                    })
                .PrimaryKey(t => t.PictureID)
                .ForeignKey("sm.Galleries", t => t.GalleryID, cascadeDelete: true)
                .Index(t => t.GalleryID);
            
            AddColumn("sm.Products", "Gallery_GalleryID", c => c.Guid());
            AlterColumn("sm.Products", "GroupID", c => c.Guid(nullable: false));
            CreateIndex("sm.Products", "GroupID");
            CreateIndex("sm.Products", "Gallery_GalleryID");
            AddForeignKey("sm.Products", "Gallery_GalleryID", "sm.Galleries", "GalleryID");
            AddForeignKey("sm.Products", "GroupID", "sm.Groups", "GroupID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("sm.Products", "GroupID", "sm.Groups");
            DropForeignKey("sm.Products", "Gallery_GalleryID", "sm.Galleries");
            DropForeignKey("sm.Pictures", "GalleryID", "sm.Galleries");
            DropForeignKey("sm.Galleries", "GalCategoryID", "sm.GalCategories");
            DropIndex("sm.Pictures", new[] { "GalleryID" });
            DropIndex("sm.Galleries", new[] { "GalCategoryID" });
            DropIndex("sm.Products", new[] { "Gallery_GalleryID" });
            DropIndex("sm.Products", new[] { "GroupID" });
            AlterColumn("sm.Products", "GroupID", c => c.Guid());
            DropColumn("sm.Products", "Gallery_GalleryID");
            DropTable("sm.Pictures");
            DropTable("sm.Galleries");
            DropTable("sm.GalCategories");
            RenameColumn(table: "sm.Products", name: "GroupID", newName: "Group_GroupID");
            CreateIndex("sm.Products", "Group_GroupID");
            AddForeignKey("sm.Products", "Group_GroupID", "sm.Groups", "GroupID");
        }
    }
}
