namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropAssistantTb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assistants", "UserAssistantId", "dbo.AspNetUsers");
            DropIndex("dbo.Assistants", new[] { "UserAssistantId" });
            DropTable("dbo.Assistants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Assistants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        UserAssistantId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Assistants", "UserAssistantId");
            AddForeignKey("dbo.Assistants", "UserAssistantId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
