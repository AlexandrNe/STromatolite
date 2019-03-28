namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sm.Articles",
                c => new
                    {
                        ArticleID = c.Guid(nullable: false),
                        ImgUrl = c.String(),
                        Title = c.String(nullable: false, maxLength: 500),
                        Abstract = c.String(),
                        ArtBody = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(),
                        Reference = c.String(),
                        Approved = c.Boolean(nullable: false),
                        CommentsEnabled = c.Boolean(nullable: false),
                        ViewCount = c.Int(),
                        Votes = c.Int(),
                        TotalRating = c.Int(),
                        SeoUrl = c.String(maxLength: 500),
                        Keywords = c.String(maxLength: 200),
                        MetaDescription = c.String(maxLength: 300),
                        Tags = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropTable("sm.Articles");
        }
    }
}
