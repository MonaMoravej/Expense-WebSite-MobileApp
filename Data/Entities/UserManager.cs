using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Entities
{
    public class UserManager : UserManager<User, long>
    {
        public UserManager(IUserStore<User, long> store) : base(store)
        {
        }

      

    }
}