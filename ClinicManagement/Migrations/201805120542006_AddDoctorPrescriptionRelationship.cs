namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorPrescriptionRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Prescriptions", "DoctorId");
            AddForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropColumn("dbo.Prescriptions", "DoctorId");
        }
    }
}
