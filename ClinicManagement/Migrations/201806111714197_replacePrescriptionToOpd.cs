namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replacePrescriptionToOpd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpdAttendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicRemarks = c.String(nullable: false),
                        Diagnosis = c.String(nullable: false, maxLength: 255),
                        SecondDiagnosis = c.String(),
                        ThirdDiagnosis = c.String(),
                        Therapy = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            AddColumn("dbo.Patients", "Sex", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "CityId", c => c.Byte(nullable: false));
            AddColumn("dbo.Patients", "Height", c => c.String());
            AddColumn("dbo.Patients", "Weight", c => c.String());
            CreateIndex("dbo.Patients", "CityId");
            AddForeignKey("dbo.Patients", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            DropTable("dbo.Prescriptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease = c.String(nullable: false, maxLength: 255),
                        Medicine = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.OpdAttendances", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "CityId", "dbo.Cities");
            DropIndex("dbo.OpdAttendances", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "CityId" });
            DropColumn("dbo.Patients", "Weight");
            DropColumn("dbo.Patients", "Height");
            DropColumn("dbo.Patients", "CityId");
            DropColumn("dbo.Patients", "BirthDate");
            DropColumn("dbo.Patients", "Sex");
            DropTable("dbo.OpdAttendances");
            DropTable("dbo.Cities");
            CreateIndex("dbo.Prescriptions", "PatientId");
            AddForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
