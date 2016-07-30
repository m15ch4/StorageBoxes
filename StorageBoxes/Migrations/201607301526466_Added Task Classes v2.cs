namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskClassesv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SBTasks", "UserID", "dbo.Users");
            DropIndex("dbo.SBTasks", new[] { "UserID" });
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.SBTasks", "User_UserID", c => c.Int());
            AddColumn("dbo.SBTasks", "User_UserName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", new[] { "UserID", "UserName" });
            CreateIndex("dbo.SBTasks", new[] { "User_UserID", "User_UserName" });
            AddForeignKey("dbo.SBTasks", new[] { "User_UserID", "User_UserName" }, "dbo.Users", new[] { "UserID", "UserName" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SBTasks", new[] { "User_UserID", "User_UserName" }, "dbo.Users");
            DropIndex("dbo.SBTasks", new[] { "User_UserID", "User_UserName" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.SBTasks", "User_UserName");
            DropColumn("dbo.SBTasks", "User_UserID");
            AddPrimaryKey("dbo.Users", "UserID");
            CreateIndex("dbo.SBTasks", "UserID");
            AddForeignKey("dbo.SBTasks", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
