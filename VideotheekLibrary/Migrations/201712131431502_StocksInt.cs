namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StocksInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DVDs", "reserved_amount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DVDs", "reserved_amount", c => c.Int(nullable: false));
        }
    }
}
