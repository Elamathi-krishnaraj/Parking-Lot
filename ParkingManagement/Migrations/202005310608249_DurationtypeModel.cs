namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DurationtypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestDurationTypes",
                c => new
                    {
                        DurationId = c.Int(nullable: false, identity: true),
                        DurationType = c.String(),
                        DurationDescription = c.String(),
                    })
                .PrimaryKey(t => t.DurationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RequestDurationTypes");
        }
    }
}
