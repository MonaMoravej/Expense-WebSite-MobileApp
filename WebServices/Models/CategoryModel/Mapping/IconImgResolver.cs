using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense_WebSite_MobileApp.Models.CategoryModel.Mapping
{
    public class IconImgResolver : IValueResolver<Category, CategoryViewModel, byte[]>
    {
        public byte[] Resolve(Category source, CategoryViewModel destination, byte[] destMember, ResolutionContext context)
        {
            if (source.Icon != null)
            {
                return source.Icon.Image;
            }
            return null;
        }
    }
}