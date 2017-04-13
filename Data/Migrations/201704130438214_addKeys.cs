namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Key", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.Category", "Key", c => c.String(nullable: false, maxLength: 7));
            AddColumn("dbo.Budget", "Key", c => c.String(nullable: false, maxLength: 14));
            AddColumn("dbo.Currency", "Key", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.Language", "Key", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.Payee", "Key", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Icon", "Key", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Icon", "Key");
            DropColumn("dbo.Payee", "Key");
            DropColumn("dbo.Language", "Key");
            DropColumn("dbo.Currency", "Key");
            DropColumn("dbo.Budget", "Key");
            DropColumn("dbo.Category", "Key");
            DropColumn("dbo.Account", "Key");
        }
    }
}
