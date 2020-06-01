namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurrenderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurrenderHistories",
                c => new
                    {
                        SurrenderHistoryId = c.Int(nullable: false, identity: true),
                        RegisterId = c.Int(nullable: false),
                        DurationId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        TowerId = c.Int(nullable: false),
                        ParkingSlotId = c.Int(nullable: false),
                        IsSurrender = c.Boolean(nullable: false),
                        IsExpires = c.Boolean(nullable: false),
                        IsAllotted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SurrenderHistoryId)
                .ForeignKey("dbo.ParkingSlots", t => t.ParkingSlotId, cascadeDelete: true)
                .ForeignKey("dbo.Registers", t => t.RegisterId, cascadeDelete: true)
                .ForeignKey("dbo.RequestDurationTypes", t => t.DurationId, cascadeDelete: true)
                .ForeignKey("dbo.Towers", t => t.TowerId, cascadeDelete: true)
                .Index(t => t.RegisterId)
                .Index(t => t.DurationId)
                .Index(t => t.TowerId)
                .Index(t => t.ParkingSlotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurrenderHistories", "TowerId", "dbo.Towers");
            DropForeignKey("dbo.SurrenderHistories", "DurationId", "dbo.RequestDurationTypes");
            DropForeignKey("dbo.SurrenderHistories", "RegisterId", "dbo.Registers");
            DropForeignKey("dbo.SurrenderHistories", "ParkingSlotId", "dbo.ParkingSlots");
            DropIndex("dbo.SurrenderHistories", new[] { "ParkingSlotId" });
            DropIndex("dbo.SurrenderHistories", new[] { "TowerId" });
            DropIndex("dbo.SurrenderHistories", new[] { "DurationId" });
            DropIndex("dbo.SurrenderHistories", new[] { "RegisterId" });
            DropTable("dbo.SurrenderHistories");
        }
    }
}
