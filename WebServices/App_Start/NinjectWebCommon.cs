//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Expense_WebSite_MobileApp.App_Start.NinjectWebCommon), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Expense_WebSite_MobileApp.App_Start.NinjectWebCommon), "Stop")]

//namespace Expense_WebSite_MobileApp.App_Start
//{
//    using System;
//    using System.Web;

//    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

//    using Ninject;
//    using Ninject.Web.Common;

//    using Data.Repositories;
//    using AutoMapper;
//    using Models.CategoryModel.Mapping;
//    using Models.UserModel.Mapping;
//    using Data.Entities;
//    using Microsoft.AspNet.Identity.EntityFramework;
//    using Microsoft.AspNet.Identity;
//    using Data;
//    using Microsoft.AspNet.Identity.Owin;
//    using Microsoft.Owin.Security;

//    public static class NinjectWebCommon 
//    {
//        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

//        /// <summary>
//        /// Starts the application
//        /// </summary>
//        public static void Start() 
//        {
//            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
//            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
//            bootstrapper.Initialize(CreateKernel);
//        }
        
//        /// <summary>
//        /// Stops the application.
//        /// </summary>
//        public static void Stop()
//        {
//            bootstrapper.ShutDown();
//        }
        
//        /// <summary>
//        /// Creates the kernel that will manage your application.
//        /// </summary>
//        /// <returns>The created kernel.</returns>
//        public static IKernel CreateKernel()
//        {
//            var kernel = new StandardKernel();
//            try
//            {
//                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
//                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

//                RegisterServices(kernel);
//                return kernel;
//            }
//            catch
//            {
//                kernel.Dispose();
//                throw;
//            }
//        }

//        /// <summary>
//        /// Load your modules or register your services here!
//        /// </summary>
//        /// <param name="kernel">The kernel.</param>
//        private static void RegisterServices(IKernel kernel)
//        {
//            // GlobalHost.DependencyResolver = new Microsoft.AspNet.SignalR.Ninject.NinjectDependencyResolver(kernel);
          
//            kernel.Bind<ICategoryRepository>().To<CategoryRepository>().InRequestScope();

     //      kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();

//            kernel.Bind<IUserStore<User, long>>().ToSelf().InRequestScope();
//           // new InjectionConstructor(typeof(ApplicationDbContext)));

//            kernel.Bind(typeof(ApplicationUserManager)).ToSelf().InRequestScope();
//            //kernel.Bind<IAuthenticationManager>(
//   // new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

//            //kernel.Bind(typeof(UserStore< User, Role, long, UserLogin, UserRole, UserClaim >)).ToSelf().InRequestScope();

//            var config = new MapperConfiguration(cfg =>
//            {

//                cfg.AddProfile<CategoryMappingProfile>();
//                cfg.AddProfile<UserMappingProfile>();

//            });

//            var mapper = config.CreateMapper();

//            kernel.Bind<MapperConfiguration>().ToMethod(c => config).InSingletonScope();
//            kernel.Bind<IMapper>().ToConstant(mapper);

//        }        
//    }
//}
