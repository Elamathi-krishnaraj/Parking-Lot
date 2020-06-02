namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurrenderFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParkingAllocations", "ParkingSlotId", "dbo.ParkingSlots");
            DropForeignKey("dbo.ParkingAllocations", "TowerId", "dbo.Towers");
            DropIndex("dbo.ParkingAllocations", new[] { "TowerId" });
            DropIndex("dbo.ParkingAllocations", new[] { "ParkingSlotId" });
            DropColumn("dbo.ParkingAllocations", "TowerId");
            DropColumn("dbo.ParkingAllocations", "ParkingSlotId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkingAllocations", "ParkingSlotId", c => c.Int(nullable: false));
            AddColumn("dbo.ParkingAllocations", "TowerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParkingAllocations", "ParkingSlotId");
            CreateIndex("dbo.ParkingAllocations", "TowerId");
            AddForeignKey("dbo.ParkingAllocations", "TowerId", "dbo.Towers", "TowerId", cascadeDelete: true);
            AddForeignKey("dbo.ParkingAllocations", "ParkingSlotId", "dbo.ParkingSlots", "ParkingSlotId", cascadeDelete: true);
        }
    }
}
