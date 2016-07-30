namespace StorageBoxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskClassesv5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SBTasks", "BoxID", "dbo.Boxes");
            DropForeignKey("dbo.SBTasks", "SBTaskStatusID", "dbo.SBTaskStatus");
            DropForeignKey("dbo.SBTasks", "SBTaskTypeID", "dbo.SBTaskTypes");
            DropIndex("dbo.SBTasks", new[] { "SBTaskTypeID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskStatusID" });
            DropIndex("dbo.SBTasks", new[] { "BoxID" });
            RenameColumn(table: "dbo.SBTasks", name: "BoxID", newName: "Box_BoxID");
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskStatusID", newName: "SBTaskStatus_SBTaskStatusID");
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskTypeID", newName: "SBTaskType_SBTaskTypeID");
            AlterColumn("dbo.SBTasks", "SBTaskType_SBTaskTypeID", c => c.Int());
            AlterColumn("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID", c => c.Int());
            AlterColumn("dbo.SBTasks", "Box_BoxID", c => c.Int());
            CreateIndex("dbo.SBTasks", "Box_BoxID");
            CreateIndex("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID");
            CreateIndex("dbo.SBTasks", "SBTaskType_SBTaskTypeID");
            AddForeignKey("dbo.SBTasks", "Box_BoxID", "dbo.Boxes", "BoxID");
            AddForeignKey("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID", "dbo.SBTaskStatus", "SBTaskStatusID");
            AddForeignKey("dbo.SBTasks", "SBTaskType_SBTaskTypeID", "dbo.SBTaskTypes", "SBTaskTypeID");
            DropColumn("dbo.SBTasks", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SBTasks", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SBTasks", "SBTaskType_SBTaskTypeID", "dbo.SBTaskTypes");
            DropForeignKey("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID", "dbo.SBTaskStatus");
            DropForeignKey("dbo.SBTasks", "Box_BoxID", "dbo.Boxes");
            DropIndex("dbo.SBTasks", new[] { "SBTaskType_SBTaskTypeID" });
            DropIndex("dbo.SBTasks", new[] { "SBTaskStatus_SBTaskStatusID" });
            DropIndex("dbo.SBTasks", new[] { "Box_BoxID" });
            AlterColumn("dbo.SBTasks", "Box_BoxID", c => c.Int(nullable: false));
            AlterColumn("dbo.SBTasks", "SBTaskStatus_SBTaskStatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.SBTasks", "SBTaskType_SBTaskTypeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskType_SBTaskTypeID", newName: "SBTaskTypeID");
            RenameColumn(table: "dbo.SBTasks", name: "SBTaskStatus_SBTaskStatusID", newName: "SBTaskStatusID");
            RenameColumn(table: "dbo.SBTasks", name: "Box_BoxID", newName: "BoxID");
            CreateIndex("dbo.SBTasks", "BoxID");
            CreateIndex("dbo.SBTasks", "SBTaskStatusID");
            CreateIndex("dbo.SBTasks", "SBTaskTypeID");
            AddForeignKey("dbo.SBTasks", "SBTaskTypeID", "dbo.SBTaskTypes", "SBTaskTypeID", cascadeDelete: true);
            AddForeignKey("dbo.SBTasks", "SBTaskStatusID", "dbo.SBTaskStatus", "SBTaskStatusID", cascadeDelete: true);
            AddForeignKey("dbo.SBTasks", "BoxID", "dbo.Boxes", "BoxID", cascadeDelete: true);
        }
    }
}
