namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTowerSlotFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurrenderHistories", "TowerParkingSlotId", c => c.Int(nullable: false));
            CreateIndex("dbo.SurrenderHistories", "TowerParkingSlotId");
            AddForeignKey("dbo.SurrenderHistories", "TowerParkingSlotId", "dbo.TowerParkingSlots", "TowerParkingSlotId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurrenderHistories", "TowerParkingSlotId", "dbo.TowerParkingSlots");
            DropIndex("dbo.SurrenderHistories", new[] { "TowerParkingSlotId" });
            DropColumn("dbo.SurrenderHistories", "TowerParkingSlotId");
        }
    }
}
