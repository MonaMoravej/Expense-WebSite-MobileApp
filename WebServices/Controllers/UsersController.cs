using AutoMapper;
using Data.Entities;
using Expense_WebSite_MobileApp.Models.UserModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Expense_WebSite_MobileApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/Auth")]
    public class UsersController : ApiController
    {
        public ApplicationUserManager UserManager { get; private set; }
        public ApplicationSignInManager SignInManager { get; private set; }
        public IMapper Mapper { get; private set; }


        public UsersController(ApplicationUserManager userManager,
            IMapper mapper, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;

            Mapper = mapper;
            SignInManager = signInManager;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(RegisterModel model)
        {
          
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Mapper.Map<RegisterModel, User>(model);
            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            //must return ok
            return Ok();
        }


        //Auth/Login --> ApplicationOAuthProvider
        //Auth/Logou --> just need js in browser and nothing here : self.logout = function () {sessionStorage.removeItem(tokenKey)}


    [Route("ChangePassword")]
        [HttpPost]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordModel model)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //getting language

           //var user =  UserManager.FindById(long.Parse(User.Identity.GetUserId()));
            IdentityResult result = await UserManager.ChangePasswordAsync(long.Parse(User.Identity.GetUserId()), model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }


        //returns data for current profile of user
        [Route("Profile")]
        [HttpGet]
        public UserInfoViewModel GetProfileInfo()
        {
            return new UserInfoViewModel();
        }


        [Route("Profile")]
        [HttpPost]
        public IHttpActionResult EditProfileInfo(UserInfoViewModel model) { return Ok(); }

       

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UserManager != null) UserManager.Dispose();
                if (SignInManager != null) SignInManager.Dispose();
               
            }
             

            base.Dispose(disposing);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
