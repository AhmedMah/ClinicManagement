namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDobToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Dob", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Dob");
        }
    }
}
