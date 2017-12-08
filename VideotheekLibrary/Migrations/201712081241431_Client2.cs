namespace VideotheekLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Client2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.clients",
                c => new
                    {
                        client_id = c.Int(nullable: false, identity: true),
                        surname = c.String(nullable: false, maxLength: 255),
                        first_name = c.String(nullable: false, maxLength: 255),
                        birth_date = c.DateTime(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.client_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.clients");
        }
    }
}
