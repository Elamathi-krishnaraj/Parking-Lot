namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TowertoslotTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TowerParkingSlots",
                c => new
                    {
                        TowerParkingSlotId = c.Int(nullable: false, identity: true),
                        ParkingSlotId = c.Int(nullable: false),
                        TowerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TowerParkingSlotId)
                .ForeignKey("dbo.ParkingSlots", t => t.ParkingSlotId, cascadeDelete: true)
                .ForeignKey("dbo.Towers", t => t.TowerId, cascadeDelete: true)
                .Index(t => t.ParkingSlotId)
                .Index(t => t.TowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TowerParkingSlots", "TowerId", "dbo.Towers");
            DropForeignKey("dbo.TowerParkingSlots", "ParkingSlotId", "dbo.ParkingSlots");
            DropIndex("dbo.TowerParkingSlots", new[] { "TowerId" });
            DropIndex("dbo.TowerParkingSlots", new[] { "ParkingSlotId" });
            DropTable("dbo.TowerParkingSlots");
        }
    }
}
