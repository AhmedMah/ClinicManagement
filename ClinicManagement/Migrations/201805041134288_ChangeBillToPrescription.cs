namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBillToPrescription : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Bills", newName: "Prescriptions");
            AddColumn("dbo.Prescriptions", "Medicine", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Prescriptions", "Prescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prescriptions", "Prescription", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Prescriptions", "Medicine");
            RenameTable(name: "dbo.Prescriptions", newName: "Bills");
        }
    }
}
