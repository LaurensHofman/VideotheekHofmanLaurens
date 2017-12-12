namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.reservations",
                c => new
                    {
                        DVD_id = c.Int(nullable: false),
                        client_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DVD_id, t.client_id })
                .ForeignKey("dbo.DVDs", t => t.DVD_id, cascadeDelete: true)
                .ForeignKey("dbo.clients", t => t.client_id, cascadeDelete: true)
                .Index(t => t.DVD_id)
                .Index(t => t.client_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.reservations", "client_id", "dbo.clients");
            DropForeignKey("dbo.reservations", "DVD_id", "dbo.DVDs");
            DropIndex("dbo.reservations", new[] { "client_id" });
            DropIndex("dbo.reservations", new[] { "DVD_id" });
            DropTable("dbo.reservations");
        }
    }
}
