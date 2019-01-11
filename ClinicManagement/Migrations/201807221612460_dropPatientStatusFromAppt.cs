namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropPatientStatusFromAppt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "StatusId", "dbo.PatientStatus");
            DropIndex("dbo.Appointments", new[] { "StatusId" });
            DropColumn("dbo.Appointments", "StatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "StatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Appointments", "StatusId");
            AddForeignKey("dbo.Appointments", "StatusId", "dbo.PatientStatus", "Id", cascadeDelete: true);
        }
    }
}
