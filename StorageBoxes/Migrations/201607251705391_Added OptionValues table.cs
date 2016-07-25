namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOptionValuestable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Options", new[] { "ProductID" });
            AlterColumn("dbo.Products", "ProductName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Options", "OptionName", c => c.String(maxLength: 200));
            CreateIndex("dbo.Products", "ProductName", unique: true);
            CreateIndex("dbo.Options", new[] { "OptionName", "ProductID" }, unique: true, name: "IX_Options");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Options", "IX_Options");
            DropIndex("dbo.Products", new[] { "ProductName" });
            AlterColumn("dbo.Options", "OptionName", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            CreateIndex("dbo.Options", "ProductID");
        }
    }
}
