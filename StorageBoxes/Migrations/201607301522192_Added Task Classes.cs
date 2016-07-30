namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.SBTasks",
                c => new
                    {
                        SBTaskID = c.Int(nullable: false, identity: true),
                        SBTaskTypeID = c.Int(nullable: false),
                        SBTaskStatusID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        BoxID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SBTaskID)
                .ForeignKey("dbo.Boxes", t => t.BoxID, cascadeDelete: true)
                .ForeignKey("dbo.SBTaskStatus", t => t.SBTaskStatusID, cascadeDelete: true)
                .ForeignKey("dbo.SBTaskTypes", t => t.SBTaskTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.SBTaskTypeID)
                .Index(t => t.SBTaskStatusID)
                .Index(t => t.UserID)
                .Index(t => t.BoxID);
            
            CreateTable(
                "dbo.SBTaskStatus",
                c => new
                    {
                        SBTaskStatusID = c.Int(nullable: false, identity: true),
                        SBTaskStatusName = c.String(),
                    })
                .PrimaryKey(t => t.SBTaskStatusID);
            
            CreateTable(
                "dbo.SBTaskTypes",
                c => new
                    {
                        SBTaskTypeID = c.Int(nullable: false, identity: true),
                        SBTaskTypeName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SBTaskTypeID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RFID = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SBTasks", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.SBTasks", "SBTaskTypeID", "dbo.SBTaskTypes");
            DropForeignKey("dbo.SBTasks", "SBTaskStatusID", "dbo.SBTaskStatus");
            DropForeignKey("dbo.SBTasks", "BoxID", "dbo.Boxes");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.SBTasks", new[] { "BoxID" });
            DropIndex("dbo.SBTasks", new[] { "UserID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskStatusID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskTypeID" });
            DropTable("dbo.Users");
            DropTable("dbo.SBTaskTypes");
            DropTable("dbo.SBTaskStatus");
            DropTable("dbo.SBTasks");
            DropTable("dbo.Roles");
        }
    }
}
