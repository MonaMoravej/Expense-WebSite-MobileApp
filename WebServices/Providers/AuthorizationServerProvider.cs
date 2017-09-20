using Data.Entities;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Expense_WebSite_MobileApp.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        private ApplicationUserManager userManager;
        public AuthorizationServerProvider(ApplicationUserManager _userManager)
        {

            userManager = _userManager;
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            User user = await userManager.FindAsync(context.UserName, context.Password);




            if (user != null)
            {
                ClaimsIdentity oAuthIdentity = await userManager.CreateIdentityAsync(user, "Bearer");
              
                //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                //identity.AddClaim(new Claim("sub", context.UserName));
                //identity.AddClaim(new Claim("UserId", user.Id.ToString()));
               // context.Validated(identity);
                context.Validated(oAuthIdentity);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");

            }

        }


       
    }
}