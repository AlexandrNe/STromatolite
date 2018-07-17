namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "sm.Products", name: "Gallery_GalleryID", newName: "GalleryID");
            RenameIndex(table: "sm.Products", name: "IX_Gallery_GalleryID", newName: "IX_GalleryID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "sm.Products", name: "IX_GalleryID", newName: "IX_Gallery_GalleryID");
            RenameColumn(table: "sm.Products", name: "GalleryID", newName: "Gallery_GalleryID");
        }
    }
}
