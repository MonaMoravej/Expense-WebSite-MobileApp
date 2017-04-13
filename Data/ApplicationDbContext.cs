using Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,long,UserLogin,UserRole,UserClaim>
    {
        public ApplicationDbContext() : base("name=DbConnection")
        {
            
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Icon> Icons { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Payee> Payees { get; set; }

        public DbSet<Transaction> Transactions { get; set; }


        protected  override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Identity tables
            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<UserClaim>().ToTable("UserClaim");

            //Application table
            builder.Entity<Account>().ToTable("Account").HasKey(a=>a.Id).Property(a=>a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            builder.Entity<Budget>().ToTable("Budget").HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            builder.Entity<Category>().ToTable("Category").HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            builder.Entity<Currency>().ToTable("Currency").HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            builder.Entity<Icon>().ToTable("Icon").HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            builder.Entity<Language>().ToTable("Language").HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            builder.Entity<Payee>().ToTable("Payee").HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            builder.Entity<Transaction>().ToTable("Transaction").HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}