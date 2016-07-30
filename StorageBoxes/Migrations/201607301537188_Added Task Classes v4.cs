namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskClassesv4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SBTaskTypes", "SBTaskTypeName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SBTaskTypes", "SBTaskTypeName", c => c.Int(nullable: false));
        }
    }
}
