namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDReservation_res : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.reservations", name: "DVD_id", newName: "res_DVD_id");
            RenameColumn(table: "dbo.reservations", name: "client_id", newName: "res_client_id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.reservations", name: "res_client_id", newName: "client_id");
            RenameColumn(table: "dbo.reservations", name: "res_DVD_id", newName: "DVD_id");
        }
    }
}
