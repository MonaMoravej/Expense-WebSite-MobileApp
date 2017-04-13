namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        StartBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpenDate = c.DateTime(nullable: false),
                        UserId = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Long(nullable: false),
                        PayeeId = c.Long(),
                        AccountId = c.Long(),
                        CategoryId = c.Long(),
                        ToAccountId = c.Long(),
                        FromAccountId = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payee", t => t.PayeeId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Account", t => t.FromAccountId)
                .ForeignKey("dbo.Account", t => t.ToAccountId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.UserId)
                .Index(t => t.PayeeId)
                .Index(t => t.AccountId)
                .Index(t => t.CategoryId)
                .Index(t => t.ToAccountId)
                .Index(t => t.FromAccountId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.Int(nullable: false),
                        UserId = c.Long(),
                        ParentId = c.Long(),
                        IconId = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Category", t => t.ParentId)
                .ForeignKey("dbo.Icon", t => t.IconId)
                .Index(t => t.UserId)
                .Index(t => t.ParentId)
                .Index(t => t.IconId);
            
            CreateTable(
                "dbo.Budget",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearMonth = c.DateTime(nullable: false),
                        UserId = c.Long(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BirthDate = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Picture = c.Binary(),
                        CurrencyId = c.Long(nullable: false),
                        LanguageId = c.Long(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.CurrencyId)
                .Index(t => t.LanguageId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Payee",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Memo = c.String(),
                        UserId = c.Long(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Icon",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Image = c.Binary(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Transaction", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Transaction", "ToAccountId", "dbo.Account");
            DropForeignKey("dbo.Transaction", "FromAccountId", "dbo.Account");
            DropForeignKey("dbo.Transaction", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "IconId", "dbo.Icon");
            DropForeignKey("dbo.Category", "ParentId", "dbo.Category");
            DropForeignKey("dbo.Transaction", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Payee", "UserId", "dbo.User");
            DropForeignKey("dbo.Transaction", "PayeeId", "dbo.Payee");
            DropForeignKey("dbo.Payee", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.User", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Category", "UserId", "dbo.User");
            DropForeignKey("dbo.Budget", "UserId", "dbo.User");
            DropForeignKey("dbo.Account", "UserId", "dbo.User");
            DropForeignKey("dbo.Budget", "CategoryId", "dbo.Category");
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Payee", new[] { "CategoryId" });
            DropIndex("dbo.Payee", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", new[] { "LanguageId" });
            DropIndex("dbo.User", new[] { "CurrencyId" });
            DropIndex("dbo.Budget", new[] { "CategoryId" });
            DropIndex("dbo.Budget", new[] { "UserId" });
            DropIndex("dbo.Category", new[] { "IconId" });
            DropIndex("dbo.Category", new[] { "ParentId" });
            DropIndex("dbo.Category", new[] { "UserId" });
            DropIndex("dbo.Transaction", new[] { "FromAccountId" });
            DropIndex("dbo.Transaction", new[] { "ToAccountId" });
            DropIndex("dbo.Transaction", new[] { "CategoryId" });
            DropIndex("dbo.Transaction", new[] { "AccountId" });
            DropIndex("dbo.Transaction", new[] { "PayeeId" });
            DropIndex("dbo.Transaction", new[] { "UserId" });
            DropIndex("dbo.Account", new[] { "UserId" });
            DropTable("dbo.Role");
            DropTable("dbo.Icon");
            DropTable("dbo.UserRole");
            DropTable("dbo.Payee");
            DropTable("dbo.UserLogin");
            DropTable("dbo.Language");
            DropTable("dbo.Currency");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Budget");
            DropTable("dbo.Category");
            DropTable("dbo.Transaction");
            DropTable("dbo.Account");
        }
    }
}
