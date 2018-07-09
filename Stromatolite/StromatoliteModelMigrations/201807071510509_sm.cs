namespace Stromatolite.StromatoliteModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sm.Currencies",
                c => new
                    {
                        CurrencyID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Abbr = c.String(),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "sm.Offers",
                c => new
                    {
                        OfferID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Quantity = c.Int(),
                        UnitID = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OfferID)
                .ForeignKey("sm.Currencies", t => t.CurrencyID, cascadeDelete: true)
                .ForeignKey("sm.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("sm.Units", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.UnitID)
                .Index(t => t.CurrencyID);
            
            CreateTable(
                "sm.Units",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.UnitID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("sm.Offers", "UnitID", "sm.Units");
            DropForeignKey("sm.Offers", "ProductID", "sm.Products");
            DropForeignKey("sm.Offers", "CurrencyID", "sm.Currencies");
            DropIndex("sm.Offers", new[] { "CurrencyID" });
            DropIndex("sm.Offers", new[] { "UnitID" });
            DropIndex("sm.Offers", new[] { "ProductID" });
            DropTable("sm.Units");
            DropTable("sm.Offers");
            DropTable("sm.Currencies");
        }
    }
}
