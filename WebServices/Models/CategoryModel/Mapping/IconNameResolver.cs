using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense_WebSite_MobileApp.Models.CategoryModel.Mapping
{
    public class IconNameResolver : IValueResolver<Category, CategoryViewModel, string>
    {
        public string Resolve(Category source, CategoryViewModel destination, string destMember, ResolutionContext context)
        {
            if (source.Icon != null)
            {
                return source.Icon.Name;
            }
            return string.Empty;
        }
    }
}