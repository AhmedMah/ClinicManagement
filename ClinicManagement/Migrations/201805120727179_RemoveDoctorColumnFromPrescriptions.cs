namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDoctorColumnFromPrescriptions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropColumn("dbo.Prescriptions", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prescriptions", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Prescriptions", "DoctorId");
            AddForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors", "Id");
        }
    }
}
