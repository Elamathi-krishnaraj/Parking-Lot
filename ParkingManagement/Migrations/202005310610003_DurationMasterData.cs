namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DurationMasterData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.RequestDurationTypes(DurationType,DurationDescription) values('1','Day');" +
               "Insert Into dbo.RequestDurationTypes(DurationType,DurationDescription) values('7','Week');" +
               "Insert Into dbo.RequestDurationTypes(DurationType,DurationDescription) values('30','Month');");
        }
        
        public override void Down()
        {
        }
    }
}
