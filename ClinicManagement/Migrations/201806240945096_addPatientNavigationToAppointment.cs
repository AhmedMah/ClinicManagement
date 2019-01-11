namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientNavigationToAppointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OpdAttendances", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.OpdAttendances", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.OpdAttendances", new[] { "PatientId" });
            DropIndex("dbo.OpdAttendances", new[] { "Appointment_Id" });
            DropIndex("dbo.Patients", new[] { "Appointment_Id" });
            RenameColumn(table: "dbo.OpdAttendances", name: "Appointment_Id", newName: "AppointmentId");
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.OpdAttendances", "AppointmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "PatientId");
            CreateIndex("dbo.OpdAttendances", "AppointmentId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OpdAttendances", "AppointmentId", "dbo.Appointments", "Id", cascadeDelete: true);
            DropColumn("dbo.OpdAttendances", "PatientId");
            DropColumn("dbo.Patients", "Appointment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Appointment_Id", c => c.Int());
            AddColumn("dbo.OpdAttendances", "PatientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OpdAttendances", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropIndex("dbo.OpdAttendances", new[] { "AppointmentId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            AlterColumn("dbo.OpdAttendances", "AppointmentId", c => c.Int());
            DropColumn("dbo.Appointments", "PatientId");
            RenameColumn(table: "dbo.OpdAttendances", name: "AppointmentId", newName: "Appointment_Id");
            CreateIndex("dbo.Patients", "Appointment_Id");
            CreateIndex("dbo.OpdAttendances", "Appointment_Id");
            CreateIndex("dbo.OpdAttendances", "PatientId");
            AddForeignKey("dbo.OpdAttendances", "Appointment_Id", "dbo.Appointments", "Id");
            AddForeignKey("dbo.Patients", "Appointment_Id", "dbo.Appointments", "Id");
            AddForeignKey("dbo.OpdAttendances", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
