namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdalltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSKUs",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductSKUID = c.Int(nullable: false),
                        Sku = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductID, t.ProductSKUID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ProductSKUID, unique: true);
            
            CreateTable(
                "dbo.SKUValues",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductSKUID = c.Int(nullable: false),
                        OptionID = c.Int(nullable: false),
                        OptionValueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.ProductSKUID, t.OptionID })
                .ForeignKey("dbo.Options", t => new { t.ProductID, t.OptionID }, cascadeDelete: false)
                .ForeignKey("dbo.OptionValues", t => new { t.ProductID, t.OptionID, t.OptionValueID }, cascadeDelete: false)
                .ForeignKey("dbo.ProductSKUs", t => new { t.ProductID, t.ProductSKUID }, cascadeDelete: false)
                .Index(t => new { t.ProductID, t.OptionID })
                .Index(t => new { t.ProductID, t.OptionID, t.OptionValueID })
                .Index(t => new { t.ProductID, t.ProductSKUID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SKUValues", new[] { "ProductID", "ProductSKUID" }, "dbo.ProductSKUs");
            DropForeignKey("dbo.SKUValues", new[] { "ProductID", "OptionID", "OptionValueID" }, "dbo.OptionValues");
            DropForeignKey("dbo.SKUValues", new[] { "ProductID", "OptionID" }, "dbo.Options");
            DropForeignKey("dbo.ProductSKUs", "ProductID", "dbo.Products");
            DropIndex("dbo.SKUValues", new[] { "ProductID", "ProductSKUID" });
            DropIndex("dbo.SKUValues", new[] { "ProductID", "OptionID", "OptionValueID" });
            DropIndex("dbo.SKUValues", new[] { "ProductID", "OptionID" });
            DropIndex("dbo.ProductSKUs", new[] { "ProductSKUID" });
            DropIndex("dbo.ProductSKUs", new[] { "ProductID" });
            DropTable("dbo.SKUValues");
            DropTable("dbo.ProductSKUs");
        }
    }
}
