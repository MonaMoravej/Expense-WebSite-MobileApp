namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKeys1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Language", "Key", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Language", "Key", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
