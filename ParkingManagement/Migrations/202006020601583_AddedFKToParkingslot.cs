namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKToParkingslot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkingAllocations", "TowerParkingSlotId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParkingAllocations", "TowerParkingSlotId");
            AddForeignKey("dbo.ParkingAllocations", "TowerParkingSlotId", "dbo.TowerParkingSlots", "TowerParkingSlotId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkingAllocations", "TowerParkingSlotId", "dbo.TowerParkingSlots");
            DropIndex("dbo.ParkingAllocations", new[] { "TowerParkingSlotId" });
            DropColumn("dbo.ParkingAllocations", "TowerParkingSlotId");
        }
    }
}
