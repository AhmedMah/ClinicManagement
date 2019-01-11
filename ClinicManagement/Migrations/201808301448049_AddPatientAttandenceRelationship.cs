namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientAttandenceRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            AddColumn("dbo.Attendances", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attendances", "PatientId");
            AddForeignKey("dbo.Attendances", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Attendances", "PatientId", "dbo.Patients");
            DropIndex("dbo.Attendances", new[] { "PatientId" });
            DropColumn("dbo.Attendances", "PatientId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "AppointmentId", "dbo.Appointments", "Id", cascadeDelete: true);
        }
    }
}
