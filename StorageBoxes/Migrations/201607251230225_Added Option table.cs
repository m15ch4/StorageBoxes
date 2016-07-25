namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOptiontable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionID = c.Int(nullable: false, identity: true),
                        OptionName = c.String(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.OptionID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.Options", new[] { "Product_ProductID" });
            DropIndex("dbo.Products", new[] { "Category_CategoryID" });
            DropTable("dbo.Options");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
