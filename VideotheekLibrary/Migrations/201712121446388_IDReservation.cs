namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDReservation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.reservations");
            AddColumn("dbo.reservations", "DVD_id", c => c.Int());
            AddColumn("dbo.reservations", "client_id", c => c.Int());
            AddColumn("dbo.reservations", "reservation_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.reservations", "created_at", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.reservations", "reservation_id");
            DropColumn("dbo.reservations", "refDVD_id");
            DropColumn("dbo.reservations", "refclient_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.reservations", "refclient_id", c => c.Int(nullable: false));
            AddColumn("dbo.reservations", "refDVD_id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.reservations");
            DropColumn("dbo.reservations", "created_at");
            DropColumn("dbo.reservations", "reservation_id");
            DropColumn("dbo.reservations", "client_id");
            DropColumn("dbo.reservations", "DVD_id");
            AddPrimaryKey("dbo.reservations", new[] { "refDVD_id", "refclient_id" });
        }
    }
}
