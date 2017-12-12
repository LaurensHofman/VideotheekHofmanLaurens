namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testRefkey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.reservations", name: "DVD_id", newName: "refDVD_id");
            RenameColumn(table: "dbo.reservations", name: "client_id", newName: "refclient_id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.reservations", name: "refclient_id", newName: "client_id");
            RenameColumn(table: "dbo.reservations", name: "refDVD_id", newName: "DVD_id");
        }
    }
}
