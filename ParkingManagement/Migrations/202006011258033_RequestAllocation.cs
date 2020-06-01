namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestAllocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkingAllocations",
                c => new
                    {
                        ParkingAllocationId = c.Int(nullable: false, identity: true),
                        RegisterId = c.Int(nullable: false),
                        DurationId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        TowerId = c.Int(nullable: false),
                        ParkingSlotId = c.Int(nullable: false),
                        IsSurrender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ParkingAllocationId)
                .ForeignKey("dbo.ParkingSlots", t => t.ParkingSlotId, cascadeDelete: true)
                .ForeignKey("dbo.Registers", t => t.RegisterId, cascadeDelete: true)
                .ForeignKey("dbo.RequestDurationTypes", t => t.DurationId, cascadeDelete: true)
                .ForeignKey("dbo.Towers", t => t.TowerId, cascadeDelete: true)
                .Index(t => t.RegisterId)
                .Index(t => t.DurationId)
                .Index(t => t.TowerId)
                .Index(t => t.ParkingSlotId);
            
            CreateTable(
                "dbo.RequestDetails",
                c => new
                    {
                        RequestDetailsId = c.Int(nullable: false, identity: true),
                        RegisterId = c.Int(nullable: false),
                        DurationId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        PreferenceOneTowerId = c.Int(nullable: false),
                        PreferenceTwoTowerId = c.Int(nullable: false),
                        PreferenceThreeTowerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestDetailsId)
                .ForeignKey("dbo.Registers", t => t.RegisterId, cascadeDelete: true)
                .ForeignKey("dbo.RequestDurationTypes", t => t.DurationId, cascadeDelete: true)
                .Index(t => t.RegisterId)
                .Index(t => t.DurationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestDetails", "DurationId", "dbo.RequestDurationTypes");
            DropForeignKey("dbo.RequestDetails", "RegisterId", "dbo.Registers");
            DropForeignKey("dbo.ParkingAllocations", "TowerId", "dbo.Towers");
            DropForeignKey("dbo.ParkingAllocations", "DurationId", "dbo.RequestDurationTypes");
            DropForeignKey("dbo.ParkingAllocations", "RegisterId", "dbo.Registers");
            DropForeignKey("dbo.ParkingAllocations", "ParkingSlotId", "dbo.ParkingSlots");
            DropIndex("dbo.RequestDetails", new[] { "DurationId" });
            DropIndex("dbo.RequestDetails", new[] { "RegisterId" });
            DropIndex("dbo.ParkingAllocations", new[] { "ParkingSlotId" });
            DropIndex("dbo.ParkingAllocations", new[] { "TowerId" });
            DropIndex("dbo.ParkingAllocations", new[] { "DurationId" });
            DropIndex("dbo.ParkingAllocations", new[] { "RegisterId" });
            DropTable("dbo.RequestDetails");
            DropTable("dbo.ParkingAllocations");
        }
    }
}
