using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense_WebSite_MobileApp.Models.CategoryModel.Mapping
{
    public class ParentResolver : IValueResolver<Category, CategoryViewModel, string>
    {
        public string Resolve(Category source, CategoryViewModel destination, string parentKey, ResolutionContext context)
        {
            if (source.Parent != null)
                return source.Parent.Key;
            return string.Empty;
        }
    }
}