namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForPatient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "Disease", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Bills", "Prescription", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Patients", "Phone", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Patients", "Address", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Address", c => c.String());
            AlterColumn("dbo.Patients", "Phone", c => c.String());
            AlterColumn("dbo.Patients", "Name", c => c.String());
            AlterColumn("dbo.Bills", "Prescription", c => c.String());
            AlterColumn("dbo.Bills", "Disease", c => c.String());
        }
    }
}
