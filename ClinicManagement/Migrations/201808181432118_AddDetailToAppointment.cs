namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailToAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Detail");
        }
    }
}
