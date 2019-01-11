namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropTokenTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "PatientId", "dbo.Patients");
            DropIndex("dbo.Tokens", new[] { "PatientId" });
            AddColumn("dbo.Patients", "Token", c => c.String(nullable: false));
            DropTable("dbo.Tokens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Patients", "Token");
            CreateIndex("dbo.Tokens", "PatientId");
            AddForeignKey("dbo.Tokens", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
