namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskClassesv7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SBTasks", new[] { "User_UserID", "User_UserName" });
            DropColumn("dbo.SBTasks", "UserID");
            RenameColumn(table: "dbo.SBTasks", name: "User_UserID", newName: "UserID");
            RenameColumn(table: "dbo.SBTasks", name: "User_UserName", newName: "UserName");
            AlterColumn("dbo.SBTasks", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.SBTasks", new[] { "UserID", "UserName" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.SBTasks", new[] { "UserID", "UserName" });
            AlterColumn("dbo.SBTasks", "UserID", c => c.Int());
            RenameColumn(table: "dbo.SBTasks", name: "UserName", newName: "User_UserName");
            RenameColumn(table: "dbo.SBTasks", name: "UserID", newName: "User_UserID");
            AddColumn("dbo.SBTasks", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.SBTasks", new[] { "User_UserID", "User_UserName" });
        }
    }
}
