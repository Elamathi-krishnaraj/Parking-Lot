namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkingSlotData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.ParkingSlots(SlotDescription) values('A-001');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('A-002');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('A-003');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('A-004');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('A-005');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('B-001'); " +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('B-002');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('B-003');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('B-004');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('B-005');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('C-001'); " +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('C-002');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('C-003');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('C-004');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('C-005');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('D-001'); " +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('D-002');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('D-003');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('D-004');" +
 "Insert Into dbo.ParkingSlots(SlotDescription) values('D-005');");
        }
        
        public override void Down()
        {
        }
    }
}
