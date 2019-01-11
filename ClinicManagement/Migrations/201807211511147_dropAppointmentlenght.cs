namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropAppointmentlenght : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "AppointmentLength");
            DropColumn("dbo.Appointments", "AppointmentStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "AppointmentLength", c => c.Int(nullable: false));
        }
    }
}
