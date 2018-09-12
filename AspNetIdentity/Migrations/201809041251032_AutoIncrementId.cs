namespace AspNetIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoIncrementId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tools");
            AddColumn("dbo.Tools", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tools", "Id");
            DropColumn("dbo.Tools", "ToolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tools", "ToolId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Tools");
            DropColumn("dbo.Tools", "Id");
            AddPrimaryKey("dbo.Tools", "ToolId");
        }
    }
}
