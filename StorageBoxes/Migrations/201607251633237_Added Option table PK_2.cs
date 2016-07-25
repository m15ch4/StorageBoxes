namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOptiontablePK_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Options", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Options", new[] { "Product_ProductID" });
            RenameColumn(table: "dbo.Options", name: "Product_ProductID", newName: "ProductID");
            DropPrimaryKey("dbo.Options");
            AlterColumn("dbo.Options", "OptionID", c => c.Int(nullable: false));
            AlterColumn("dbo.Options", "ProductID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Options", new[] { "OptionID", "ProductID" });
            CreateIndex("dbo.Options", "ProductID");
            AddForeignKey("dbo.Options", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "ProductID", "dbo.Products");
            DropIndex("dbo.Options", new[] { "ProductID" });
            DropPrimaryKey("dbo.Options");
            AlterColumn("dbo.Options", "ProductID", c => c.Int());
            AlterColumn("dbo.Options", "OptionID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Options", "OptionID");
            RenameColumn(table: "dbo.Options", name: "ProductID", newName: "Product_ProductID");
            CreateIndex("dbo.Options", "Product_ProductID");
            AddForeignKey("dbo.Options", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
