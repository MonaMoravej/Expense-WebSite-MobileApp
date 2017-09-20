using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Data.Entities
{
    public class User : IdentityUser<long,UserLogin,UserRole,UserClaim>
      
    {
        public DateTime? BirthDate { get; set; }

        [Required]
        public HumanGender Gender { get; set; }


        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public byte[] Picture { get; set; }


        // navigation properties
        [Required]
        public long CurrencyId { get; set; }

        [Required]
        public long LanguageId { get; set; }

        public Currency Currency { get; set; }

        public Language Language { get; set; }

        //navigation to Expense
        public ICollection<Account> Accounts { get;  set; }


        public ICollection<Budget> Budgets { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Payee> Payees { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public static implicit operator IdentityUser(User v)
        {
            throw new NotImplementedException();
           

        }

      
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User,Guid> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
    }



}