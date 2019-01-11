namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStringLengthFromMedicine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prescriptions", "Medicine", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prescriptions", "Medicine", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
