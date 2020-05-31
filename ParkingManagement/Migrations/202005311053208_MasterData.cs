namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasterData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Towers(TowerDescription) values('Tower 1');" +
             "Insert Into dbo.Towers(TowerDescription) values('Tower 2');" +
             "Insert Into dbo.Towers(TowerDescription) values('Tower 3');");

            Sql("Insert Into dbo.TowerBlocks(BlockDescription) values('A-Block');" +
             "Insert Into dbo.TowerBlocks(BlockDescription) values('B-Block');" +
             "Insert Into dbo.TowerBlocks(BlockDescription) values('C-Block');" +
             "Insert Into dbo.TowerBlocks(BlockDescription) values('D-Block')");

            Sql("Insert Into dbo.TowerBlockSlots(SlotDescription) values('001');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('002');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('003');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('004');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('005');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('006');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('007');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('008');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('009');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('010');" +
             "Insert Into dbo.TowerBlockSlots(SlotDescription) values('011');");
        }
        
        public override void Down()
        {
        }
    }
}
