namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DVDs", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.DVDs", "price_per_day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDs", "price_per_day", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.DVDs", "price");
        }
    }
}
