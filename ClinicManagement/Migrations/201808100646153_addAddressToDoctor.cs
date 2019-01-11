namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "Address", c => c.String());
            DropColumn("dbo.Doctors", "Available");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Available", c => c.Boolean(nullable: false));
            DropColumn("dbo.Doctors", "Address");
            DropColumn("dbo.Doctors", "IsAvailable");
        }
    }
}
