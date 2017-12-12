namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetFullClientsDetailsBLClient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.reservations", "res_DVD_id", c => c.Int(nullable: false));
            AlterColumn("dbo.reservations", "res_client_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.reservations", "res_client_id", c => c.Int());
            AlterColumn("dbo.reservations", "res_DVD_id", c => c.Int());
        }
    }
}
