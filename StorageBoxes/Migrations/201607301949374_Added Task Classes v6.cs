namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskClassesv6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SBTasks", "Box_BoxID", "dbo.Boxes");
            DropForeignKey("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID", "dbo.SBTaskStatus");
            DropForeignKey("dbo.SBTasks", "SBTaskType_SBTaskTypeID", "dbo.SBTaskTypes");
            DropIndex("dbo.SBTasks", new[] { "Box_BoxID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskStatus_SBTaskStatusID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskType_SBTaskTypeID" });
            RenameColumn(table: "dbo.SBTasks", name: "Box_BoxID", newName: "BoxID");
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskStatus_SBTaskStatusID", newName: "SBTaskStatusID");
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskType_SBTaskTypeID", newName: "SBTaskTypeID");
            AddColumn("dbo.SBTasks", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.SBTasks", "BoxID", c => c.Int(nullable: false));
            AlterColumn("dbo.SBTasks", "SBTaskStatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.SBTasks", "SBTaskTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.SBTasks", "SBTaskTypeID");
            CreateIndex("dbo.SBTasks", "SBTaskStatusID");
            CreateIndex("dbo.SBTasks", "BoxID");
            AddForeignKey("dbo.SBTasks", "BoxID", "dbo.Boxes", "BoxID", cascadeDelete: true);
            AddForeignKey("dbo.SBTasks", "SBTaskStatusID", "dbo.SBTaskStatus", "SBTaskStatusID", cascadeDelete: true);
            AddForeignKey("dbo.SBTasks", "SBTaskTypeID", "dbo.SBTaskTypes", "SBTaskTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SBTasks", "SBTaskTypeID", "dbo.SBTaskTypes");
            DropForeignKey("dbo.SBTasks", "SBTaskStatusID", "dbo.SBTaskStatus");
            DropForeignKey("dbo.SBTasks", "BoxID", "dbo.Boxes");
            DropIndex("dbo.SBTasks", new[] { "BoxID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskStatusID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskTypeID" });
            AlterColumn("dbo.SBTasks", "SBTaskTypeID", c => c.Int());
            AlterColumn("dbo.SBTasks", "SBTaskStatusID", c => c.Int());
            AlterColumn("dbo.SBTasks", "BoxID", c => c.Int());
            DropColumn("dbo.SBTasks", "UserID");
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskTypeID", newName: "SBTaskType_SBTaskTypeID");
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskStatusID", newName: "SBTaskStatus_SBTaskStatusID");
            RenameColumn(table: "dbo.SBTasks", name: "BoxID", newName: "Box_BoxID");
            CreateIndex("dbo.SBTasks", "SBTaskType_SBTaskTypeID");
            CreateIndex("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID");
            CreateIndex("dbo.SBTasks", "Box_BoxID");
            AddForeignKey("dbo.SBTasks", "SBTaskType_SBTaskTypeID", "dbo.SBTaskTypes", "SBTaskTypeID");
            AddForeignKey("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID", "dbo.SBTaskStatus", "SBTaskStatusID");
            AddForeignKey("dbo.SBTasks", "Box_BoxID", "dbo.Boxes", "BoxID");
        }
    }
}
