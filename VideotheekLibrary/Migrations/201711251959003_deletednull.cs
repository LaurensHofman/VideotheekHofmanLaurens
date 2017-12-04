namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletednull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DVDs", "deleted_at", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DVDs", "deleted_at", c => c.DateTime(nullable: false));
        }
    }
}
