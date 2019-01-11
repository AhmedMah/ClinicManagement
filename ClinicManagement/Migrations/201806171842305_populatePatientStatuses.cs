namespace ClinicManagement.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populatePatientStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PatientStatus (Id, Name) VALUES (1, 'Check up')");
            Sql("INSERT INTO PatientStatus (Id, Name) VALUES (2, 'Discharge')");
            Sql("INSERT INTO PatientStatus (Id, Name) VALUES (3, 'Operation')");
        }

        public override void Down()
        {
            Sql("DELETE FROM PatientStatuses WHERE Id IN (1,2,3)");
        }
    }
}
