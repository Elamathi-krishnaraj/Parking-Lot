namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actionlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actionlogs",
                c => new
                    {
                        ActionLogId = c.Int(nullable: false, identity: true),
                        ControllerDescrption = c.String(),
                        ActionExectionInfo = c.String(),
                        IPAddressInfo = c.String(),
                        DateTimeInfo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActionLogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Actionlogs");
        }
    }
}
