namespace AspNetIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToolsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        ToolId = c.String(nullable: false, maxLength: 128),
                        ToolName = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ToolId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tools", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tools", new[] { "UserId" });
            DropTable("dbo.Tools");
        }
    }
}
