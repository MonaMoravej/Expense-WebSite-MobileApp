﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Entities
{
    public class Role: IdentityRole<long,UserRole>
    {
    }
}