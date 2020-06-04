namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actionlogtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actionlogs", "ExectionTime", c => c.String());
            DropColumn("dbo.Actionlogs", "DateTimeInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actionlogs", "DateTimeInfo", c => c.DateTime(nullable: false));
            DropColumn("dbo.Actionlogs", "ExectionTime");
        }
    }
}
