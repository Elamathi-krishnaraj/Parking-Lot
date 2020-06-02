namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAllFKinSurrender : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurrenderHistories", "TowerId", "dbo.Towers");
            DropIndex("dbo.SurrenderHistories", new[] { "TowerId" });
            DropColumn("dbo.SurrenderHistories", "TowerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurrenderHistories", "TowerId", c => c.Int(nullable: false));
            CreateIndex("dbo.SurrenderHistories", "TowerId");
            AddForeignKey("dbo.SurrenderHistories", "TowerId", "dbo.Towers", "TowerId", cascadeDelete: true);
        }
    }
}
