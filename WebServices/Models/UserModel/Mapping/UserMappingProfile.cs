using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense_WebSite_MobileApp.Models.UserModel.Mapping
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            long lanId = 1;
            long curId = 1;
            CreateMap<RegisterModel, User>().AfterMap((src,des)=> {
                des.CurrencyId = curId;
                des.LanguageId = lanId;
                des.Gender = HumanGender.Male;


                });

           
        }
    }
}