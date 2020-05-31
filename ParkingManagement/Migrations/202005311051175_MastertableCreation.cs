namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MastertableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TowerBlocks",
                c => new
                    {
                        TowerBlockId = c.Int(nullable: false, identity: true),
                        BlockDescription = c.String(),
                    })
                .PrimaryKey(t => t.TowerBlockId);
            
            CreateTable(
                "dbo.TowerBlockSlots",
                c => new
                    {
                        TowerBlockSlotId = c.Int(nullable: false, identity: true),
                        SlotDescription = c.String(),
                    })
                .PrimaryKey(t => t.TowerBlockSlotId);
            
            CreateTable(
                "dbo.Towers",
                c => new
                    {
                        TowerId = c.Int(nullable: false, identity: true),
                        TowerDescription = c.String(),
                    })
                .PrimaryKey(t => t.TowerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Towers");
            DropTable("dbo.TowerBlockSlots");
            DropTable("dbo.TowerBlocks");
        }
    }
}
