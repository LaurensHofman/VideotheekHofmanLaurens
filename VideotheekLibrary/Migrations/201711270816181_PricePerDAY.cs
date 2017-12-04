namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PricePerDAY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DVDs", "price_per_day", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.DVDs", "price_per_week");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDs", "price_per_week", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.DVDs", "price_per_day");
        }
    }
}
