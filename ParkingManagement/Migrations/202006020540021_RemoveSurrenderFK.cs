namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSurrenderFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurrenderHistories", "ParkingSlotId", "dbo.ParkingSlots");
            DropIndex("dbo.SurrenderHistories", new[] { "ParkingSlotId" });
            DropColumn("dbo.SurrenderHistories", "ParkingSlotId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurrenderHistories", "ParkingSlotId", c => c.Int(nullable: false));
            CreateIndex("dbo.SurrenderHistories", "ParkingSlotId");
            AddForeignKey("dbo.SurrenderHistories", "ParkingSlotId", "dbo.ParkingSlots", "ParkingSlotId", cascadeDelete: true);
        }
    }
}
