namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResDVDDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.reservations", "dvd_full_details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.reservations", "dvd_full_details");
        }
    }
}
