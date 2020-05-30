namespace ParkingManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.UserRoles(RoleName) values('Admin');" +
             "Insert Into dbo.UserRoles(RoleName) values('User');");
        }
        
        public override void Down()
        {
        }
    }
}
