namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentAndDoctorAvail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Patients", "StatusId", "dbo.PatientStatus");
            DropIndex("dbo.Patients", new[] { "StatusId" });
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Time = c.String(),
                        StatusId = c.Byte(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.PatientStatus", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.DoctorId);
            
            AddColumn("dbo.Doctors", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "Appointment_Id", c => c.Int());
            AddColumn("dbo.OpdAttendances", "Appointment_Id", c => c.Int());
            CreateIndex("dbo.OpdAttendances", "Appointment_Id");
            CreateIndex("dbo.Patients", "Appointment_Id");
            AddForeignKey("dbo.OpdAttendances", "Appointment_Id", "dbo.Appointments", "Id");
            AddForeignKey("dbo.Patients", "Appointment_Id", "dbo.Appointments", "Id");
            DropColumn("dbo.Patients", "StatusId");
            DropColumn("dbo.Patients", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "StatusId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Appointments", "StatusId", "dbo.PatientStatus");
            DropForeignKey("dbo.Patients", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.OpdAttendances", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "Appointment_Id" });
            DropIndex("dbo.OpdAttendances", new[] { "Appointment_Id" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "StatusId" });
            DropColumn("dbo.OpdAttendances", "Appointment_Id");
            DropColumn("dbo.Patients", "Appointment_Id");
            DropColumn("dbo.Doctors", "Available");
            DropTable("dbo.Appointments");
            CreateIndex("dbo.Patients", "DoctorId");
            CreateIndex("dbo.Patients", "StatusId");
            AddForeignKey("dbo.Patients", "StatusId", "dbo.PatientStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
