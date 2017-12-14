namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DVDs", "yt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DVDs", "yt");
        }
    }
}
