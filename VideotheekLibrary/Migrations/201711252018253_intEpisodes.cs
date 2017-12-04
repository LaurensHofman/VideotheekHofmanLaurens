namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intEpisodes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DVDs", "series_episodes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DVDs", "series_episodes", c => c.String());
        }
    }
}
