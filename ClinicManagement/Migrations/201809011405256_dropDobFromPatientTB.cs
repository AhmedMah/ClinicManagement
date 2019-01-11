namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropDobFromPatientTB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "Dob");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
