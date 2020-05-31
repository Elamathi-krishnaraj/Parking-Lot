namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlotRequestModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlotRequestDeatils",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        Remarks = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        IsSlotAllotted = c.Boolean(nullable: false),
                        EmployeeName = c.String(),
                        IsSurrender = c.Boolean(nullable: false),
                        RegisterId = c.Int(nullable: false),
                        DurationId = c.Int(nullable: false),
                        TowerId = c.Int(nullable: false),
                        TowerBlockId = c.Int(nullable: false),
                        TowerBlockSlotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Registers", t => t.RegisterId, cascadeDelete: true)
                .ForeignKey("dbo.RequestDurationTypes", t => t.DurationId, cascadeDelete: true)
                .ForeignKey("dbo.Towers", t => t.TowerId, cascadeDelete: true)
                .ForeignKey("dbo.TowerBlocks", t => t.TowerBlockId, cascadeDelete: true)
                .ForeignKey("dbo.TowerBlockSlots", t => t.TowerBlockSlotId, cascadeDelete: true)
                .Index(t => t.RegisterId)
                .Index(t => t.DurationId)
                .Index(t => t.TowerId)
                .Index(t => t.TowerBlockId)
                .Index(t => t.TowerBlockSlotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SlotRequestDeatils", "TowerBlockSlotId", "dbo.TowerBlockSlots");
            DropForeignKey("dbo.SlotRequestDeatils", "TowerBlockId", "dbo.TowerBlocks");
            DropForeignKey("dbo.SlotRequestDeatils", "TowerId", "dbo.Towers");
            DropForeignKey("dbo.SlotRequestDeatils", "DurationId", "dbo.RequestDurationTypes");
            DropForeignKey("dbo.SlotRequestDeatils", "RegisterId", "dbo.Registers");
            DropIndex("dbo.SlotRequestDeatils", new[] { "TowerBlockSlotId" });
            DropIndex("dbo.SlotRequestDeatils", new[] { "TowerBlockId" });
            DropIndex("dbo.SlotRequestDeatils", new[] { "TowerId" });
            DropIndex("dbo.SlotRequestDeatils", new[] { "DurationId" });
            DropIndex("dbo.SlotRequestDeatils", new[] { "RegisterId" });
            DropTable("dbo.SlotRequestDeatils");
        }
    }
}
