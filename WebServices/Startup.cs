using System;
using Microsoft.Owin;
using Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Data.Repositories;
using Data;
using Microsoft.AspNet.Identity;
using Data.Entities;
using AutoMapper;
using Expense_WebSite_MobileApp.Models.CategoryModel.Mapping;
using Expense_WebSite_MobileApp.Models.UserModel.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using Ninject.Web.WebApi.OwinHost;
using Expense_WebSite_MobileApp.Providers;

[assembly: OwinStartup(typeof(Expense_WebSite_MobileApp.Startup))]

namespace Expense_WebSite_MobileApp
{
    public partial class Startup
    {
        private IKernel kernel = null;
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            kernel = CreateKernel();
            app.UseNinjectMiddleware(() => kernel);
            //ConfigureAuth(app);
            ConfigureOAuth(app);

            //todo get dependencies

             WebApiConfig.Register(config);
             app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

             app.UseNinjectWebApi(config);

        }

        public IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {

                // TODO: Put any other injection which are required.
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            //for using OAuth
            kernel.Bind<AuthorizationServerProvider>().ToSelf();

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();

            kernel.Bind<DbContext>().To<ApplicationDbContext>();
            kernel.Bind<IUserStore<User, long>>().To<UserStore<User, Role, long, UserLogin, UserRole, UserClaim>>();

            kernel.Bind<ApplicationUserManager>().ToSelf();

            kernel.Bind<IAuthenticationManager>().ToMethod(
                x => HttpContext.Current.GetOwinContext().Authentication
           );


            kernel.Bind<ApplicationSignInManager>().ToSelf();



            var config = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile<CategoryMappingProfile>();
                cfg.AddProfile<UserMappingProfile>();

            });

            var mapper = config.CreateMapper();

            kernel.Bind<MapperConfiguration>().ToMethod(c => config).InSingletonScope();
            kernel.Bind<IMapper>().ToConstant(mapper);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {

            var service = kernel.Get<AuthorizationServerProvider>();
            

            string tokenTimeout = ConfigurationManager.AppSettings["DefaultAuthTokenDurationInDays"];
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/Auth/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(Double.Parse(tokenTimeout)),
                
                Provider = service //new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
           
        }
    }
}






