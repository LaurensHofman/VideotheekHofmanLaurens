namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DVDs", "movie_duration", c => c.Int());
            AlterColumn("dbo.DVDs", "series_episodes", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DVDs", "series_episodes", c => c.Int(nullable: false));
            AlterColumn("dbo.DVDs", "movie_duration", c => c.Int(nullable: false));
        }
    }
}
