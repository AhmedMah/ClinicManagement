namespace ClinicManagement.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addAssistant : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Receptionists", "Raceptionist_Id", "dbo.AspNetUsers");
            //DropIndex("dbo.Receptionists", new[] { "Raceptionist_Id" });
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAssistantId, cascadeDelete: true)
                .Index(t => t.UserAssistantId);

            //DropTable("dbo.Receptionists");
        }

        public override void Down()
        {
            //CreateTable(
            //    "dbo.Receptionists",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Phone = c.String(nullable: false),
            //            Address = c.String(),
            //            ReceptionistId = c.String(nullable: false),
            //            Raceptionist_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id);

            DropForeignKey("dbo.Assistants", "UserAssistantId", "dbo.AspNetUsers");
            DropIndex("dbo.Assistants", new[] { "UserAssistantId" });
            DropTable("dbo.Assistants");
            //CreateIndex("dbo.Receptionists", "Raceptionist_Id");
            //AddForeignKey("dbo.Receptionists", "Raceptionist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
