namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sm.Products",
                c => new
                    {
                        ProductID = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        TitleFull = c.String(nullable: false, maxLength: 500),
                        Article = c.String(maxLength: 25),
                        Description = c.String(),
                        SEOurl = c.String(),
                        Active = c.Boolean(nullable: false),
                        Tags = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 300),
                        KeyWords = c.String(maxLength: 200),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("sm.Products");
        }
    }
}
