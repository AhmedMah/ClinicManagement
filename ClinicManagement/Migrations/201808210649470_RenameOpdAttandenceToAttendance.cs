namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameOpdAttandenceToAttendance : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OpdAttendances", newName: "Attendances");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Attendances", newName: "OpdAttendances");
        }
    }
}
