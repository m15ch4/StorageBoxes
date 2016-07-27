namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdalltablesv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OptionValues", new[] { "ProductID", "OptionID" }, "dbo.Options");
            DropForeignKey("dbo.SKUValues", new[] { "ProductID", "OptionID" }, "dbo.Options");
            DropPrimaryKey("dbo.Options");
            AddPrimaryKey("dbo.Options", new[] { "ProductID", "OptionID" });
            AddForeignKey("dbo.OptionValues", new[] { "ProductID", "OptionID" }, "dbo.Options", new[] { "ProductID", "OptionID" }, cascadeDelete: true);
            AddForeignKey("dbo.SKUValues", new[] { "ProductID", "OptionID" }, "dbo.Options", new[] { "ProductID", "OptionID" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SKUValues", new[] { "ProductID", "OptionID" }, "dbo.Options");
            DropForeignKey("dbo.OptionValues", new[] { "ProductID", "OptionID" }, "dbo.Options");
            DropPrimaryKey("dbo.Options");
            AddPrimaryKey("dbo.Options", new[] { "OptionID", "ProductID" });
            AddForeignKey("dbo.SKUValues", new[] { "ProductID", "OptionID" }, "dbo.Options", new[] { "OptionID", "ProductID" }, cascadeDelete: true);
            AddForeignKey("dbo.OptionValues", new[] { "ProductID", "OptionID" }, "dbo.Options", new[] { "OptionID", "ProductID" }, cascadeDelete: true);
        }
    }
}
