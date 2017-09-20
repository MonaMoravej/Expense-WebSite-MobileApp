using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Data.Entities;
using Data;
using Expense_WebSite_MobileApp.Models;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.Owin.Security.DataProtection;

namespace Expense_WebSite_MobileApp
{
    // Configure the application user manager used in this application.
    //UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<User, long>
    {
        public ApplicationUserManager(IUserStore<User, long> store)
            : base(store)
        {

            this.UserValidator = new UserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
               // RequiredLength = 6,
              //  RequireNonLetterOrDigit = true,
              //  RequireDigit = true,
                RequireLowercase = true,
               // RequireUppercase = true,
            };

            //var dataProtectionProvider = Startup.DataProtectionProvider;

            // this is unchanged
            //if (dataProtectionProvider != null)
            //{
            //    IDataProtector dataProtector = dataProtectionProvider.Create("ASP.NET Identity");

            //    this.UserTokenProvider = new DataProtectorTokenProvider<User, long>(dataProtector);
            //}




        }


    }

    // Configure the application sign-in manager which is used in this application.  
    public class ApplicationSignInManager : SignInManager<User, long>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager,
            IAuthenticationManager authenticationManager) :

            base(userManager,
                authenticationManager)
        { }


    }


}


//public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
//{
//    return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
//}

//public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
//{
//    return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
//}