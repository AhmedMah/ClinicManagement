namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentStatusToAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Appointments", "Detail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Detail", c => c.String());
            DropColumn("dbo.Appointments", "Status");
        }
    }
}
