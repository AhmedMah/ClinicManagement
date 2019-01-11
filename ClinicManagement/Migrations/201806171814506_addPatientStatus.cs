namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "StatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Patients", "StatusId");
            AddForeignKey("dbo.Patients", "StatusId", "dbo.PatientStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "StatusId", "dbo.PatientStatus");
            DropIndex("dbo.Patients", new[] { "StatusId" });
            DropColumn("dbo.Patients", "StatusId");
            DropTable("dbo.PatientStatus");
        }
    }
}
