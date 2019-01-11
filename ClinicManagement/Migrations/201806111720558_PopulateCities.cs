namespace ClinicManagement.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cities (Id,Name) VALUES (1,'Arabsiyo')");
            Sql("INSERT INTO Cities (Id,Name) VALUES (2,'Aynabo')");
            Sql("INSERT INTO Cities (Id,Name) VALUES (3,'Burao')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (4,'Borama')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (5, 'Berbera')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (6, 'Badhan')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (7, 'Buhodle')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (8, 'Baligubale')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (9, 'Dila')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (10, 'Erigavo')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (11, 'ElAfweyn')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (12, 'Gebiley')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (13, 'Garadag')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (14, 'Hargeisa')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (15, 'Las Anod')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (16, 'Lasqorey')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (17,'Lughaya')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (18, 'Kalabaydh')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (19, 'Maydh')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (20, 'Oog')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (21, 'Oodweyne')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (22, 'Sheikh')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (23, 'Salahley')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (24, 'Taleh')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (25, 'Togwajale')");
            Sql("INSERT INTO Cities (Id, Name) VALUES (26, 'Zeila')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Cities WHERE Id IN (1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26)");
        }
    }
}
