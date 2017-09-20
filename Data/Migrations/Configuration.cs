namespace Data.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
            //MigrationsDirectory = @"DatabaseConfig/Migrations";
        }

        protected override void Seed(Data.ApplicationDbContext context)
        {
            AddCategories(context);
            AddIcons(context);
            AddCurrencies(context);
            AddLanguages(context);
            AddDefualtUser(context);
        }


        private void AddCategories(ApplicationDbContext db)
        {
            if (!db.Categories.Any())
            {
                var Auto = new Category() { Name = "Auto",Key="E-Auto", Type = CategoryType.Expense };
                db.Categories.Add(new Category() { Name = "Salary",Key="I-Salar", Type = CategoryType.Income });
                db.Categories.Add(Auto);
                db.SaveChanges();

                db.Categories.Add(new Category() { Name = "Gas", Key="E-AutoG",Type = CategoryType.Expense, ParentId = Auto.Id });


                db.SaveChanges();
            }
        }


        private void AddIcons(ApplicationDbContext db)
        {
            
                if (!db.Icons.Any())
                {
                    db.Icons.Add(new Icon() { Name = "Home" ,Key="HOM"});
                 db.SaveChanges();
                }
           
        }


        private void AddLanguages(ApplicationDbContext db)
        {
            if (!db.Languages.Any())
            {
                db.Languages.Add(new Language() { Name = "English" ,Key="en-US"});
                db.Languages.Add(new Language() { Name = "فارسی",Key="fa" });
               
                db.SaveChanges();
            }
        }
        private void AddCurrencies(ApplicationDbContext db)
        {
            if (!db.Currencies.Any())
            {
                db.Currencies.Add(new Currency() { Name = "MYR" ,Key="MYR"});
                db.Currencies.Add(new Currency() { Name = "IRR" ,Key="IRR"});
                db.Currencies.Add(new Currency() { Name = "USD" ,Key="USD"});
                db.SaveChanges();
            }
        }


        private void AddDefualtUser(ApplicationDbContext db)
        {
            var manager = new UserManager(new UserStore<User, Role, long, UserLogin, UserRole, UserClaim>(db));
            var rst = manager.Create(new User() {
                Email = "mona.moravej@gmail.com",
                Gender =0,
                LanguageId =1,
                CurrencyId =1,
                EmailConfirmed =false,
                PhoneNumberConfirmed =false,
                TwoFactorEnabled =false,
                LockoutEnabled =false,
                AccessFailedCount =3,
                UserName ="Mona"
            }, "mona1!");
           
        }

    }
}
