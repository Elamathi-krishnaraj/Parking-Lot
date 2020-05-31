namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterConflict : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SlotRequestDeatils", name: "RegisterId", newName: "SlotRegisterId");
            RenameIndex(table: "dbo.SlotRequestDeatils", name: "IX_RegisterId", newName: "IX_SlotRegisterId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SlotRequestDeatils", name: "IX_SlotRegisterId", newName: "IX_RegisterId");
            RenameColumn(table: "dbo.SlotRequestDeatils", name: "SlotRegisterId", newName: "RegisterId");
        }
    }
}
