namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientFullDetReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.reservations", "client_full_details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.reservations", "client_full_details");
        }
    }
}
