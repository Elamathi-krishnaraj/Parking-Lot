namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkingSlotTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkingSlots",
                c => new
                    {
                        ParkingSlotId = c.Int(nullable: false, identity: true),
                        SlotDescription = c.String(),
                    })
                .PrimaryKey(t => t.ParkingSlotId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkingSlots");
        }
    }
}
