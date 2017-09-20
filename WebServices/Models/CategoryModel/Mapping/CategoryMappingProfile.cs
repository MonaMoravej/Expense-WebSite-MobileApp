using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense_WebSite_MobileApp.Models.CategoryModel.Mapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ForMember(cm => cm.Etag, opt => opt.MapFrom("RowVersion"))
               .ForMember(cm => cm.TypeName, opt => opt.ResolveUsing(c => c.Type.ToString()))
               .ForMember(cm => cm.IconImg, opt => opt.ResolveUsing<IconImgResolver>())
               .ForMember(cm => cm.IconName, opt => opt.ResolveUsing<IconNameResolver>())
               //.
               .MaxDepth(2);
            // .ForMember(cm => cm.Parent, opt => opt.ResolveUsing<ParentResolver>());

        }
    }
}