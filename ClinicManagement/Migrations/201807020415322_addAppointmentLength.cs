namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAppointmentLength : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentLength", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "AppointmentLength");
        }
    }
}
