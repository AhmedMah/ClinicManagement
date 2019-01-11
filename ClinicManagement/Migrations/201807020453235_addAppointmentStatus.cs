namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAppointmentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "StartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "AppointmentStatusId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "Start");
            DropColumn("dbo.Appointments", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Time", c => c.String());
            AddColumn("dbo.Appointments", "Start", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "AppointmentStatusId");
            DropColumn("dbo.Appointments", "StartDateTime");
        }
    }
}
