namespace ClinicManagement.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateSpecializations : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Specializations ( Name) VALUES ('ENT')");
            Sql("INSERT INTO  Specializations  ( Name) VALUES ('Neurology')");
            Sql("INSERT INTO  Specializations  ( Name) VALUES ('Gynaecology')");
            Sql("INSERT INTO  Specializations  ( Name) VALUES ('Podiatry')");
            Sql("INSERT INTO  Specializations  ( Name) VALUES ('Urology')");
            Sql("INSERT INTO  Specializations  ( Name) VALUES ('Dentistry')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Specializations WHERE Id IN (1,2,3,4,5,6)");
        }
    }
}
