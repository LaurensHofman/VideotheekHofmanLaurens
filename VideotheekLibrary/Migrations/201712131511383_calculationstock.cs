namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calculationstock : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DVDs", "available_stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDs", "available_stock", c => c.Int());
        }
    }
}
