namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientDoctorRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "DoctorId");
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropColumn("dbo.Patients", "DoctorId");
        }
    }
}
