namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noYT : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DVDs", "yt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDs", "yt", c => c.String());
        }
    }
}
