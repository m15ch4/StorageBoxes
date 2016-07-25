namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOptionValuestablev2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OptionValues",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        OptionID = c.Int(nullable: false),
                        OptionValueID = c.Int(nullable: false),
                        ValueName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.ProductID, t.OptionID, t.OptionValueID })
                .ForeignKey("dbo.Options", t => new { t.ProductID, t.OptionID }, cascadeDelete: true)
                .Index(t => new { t.ProductID, t.OptionID, t.ValueName }, unique: true, name: "IX_OptionValues");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OptionValues", new[] { "ProductID", "OptionID" }, "dbo.Options");
            DropIndex("dbo.OptionValues", "IX_OptionValues");
            DropTable("dbo.OptionValues");
        }
    }
}
