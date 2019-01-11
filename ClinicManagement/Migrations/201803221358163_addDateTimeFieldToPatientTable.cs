namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateTimeFieldToPatientTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DateTime");
        }
    }
}
