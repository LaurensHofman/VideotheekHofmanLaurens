namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stocks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        DVD_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        stock = c.Int(nullable: false),
                        available_stock = c.Int(),
                        reserved_amount = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        director = c.String(),
                        description = c.String(),
                        PEGI_age = c.Int(),
                        genres = c.String(),
                        DVD_type = c.String(),
                        movie_duration = c.Int(),
                        series_episodes = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.DVD_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DVDs");
        }
    }
}
