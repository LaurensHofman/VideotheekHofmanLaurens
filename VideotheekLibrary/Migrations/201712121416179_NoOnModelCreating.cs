namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoOnModelCreating : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.reservations", newName: "DVDClients");
            DropIndex("dbo.DVDClients", new[] { "DVD_id" });
            DropIndex("dbo.DVDClients", new[] { "client_id" });
            CreateTable(
                "dbo.reservations",
                c => new
                    {
                        DVD_id = c.Int(nullable: false),
                        client_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DVD_id, t.client_id });
            
            CreateIndex("dbo.DVDClients", "DVD_ID");
            CreateIndex("dbo.DVDClients", "Client_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DVDClients", new[] { "Client_ID" });
            DropIndex("dbo.DVDClients", new[] { "DVD_ID" });
            DropTable("dbo.reservations");
            CreateIndex("dbo.DVDClients", "client_id");
            CreateIndex("dbo.DVDClients", "DVD_id");
            RenameTable(name: "dbo.DVDClients", newName: "reservations");
        }
    }
}
