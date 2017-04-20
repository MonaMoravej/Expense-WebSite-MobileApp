using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expense_WebSite_MobileApp.Models.CategoryModel
{
    public class CategoryViewModel
    {

        [Required]
        [StringLength(7)] // [I/E]-5 char for categoryName ,eg.I-AutoG
        public string Key { get; set; }


        public byte[] Etag { get; set; }

        [Required]
        public string Name { get; set; }

        public string TypeName { get; set; }

        public byte[] IconImg { get; set; }

        public string IconName { get; set; }

         public CategoryViewModel Parent { get; set; }

        public ICollection<CategoryViewModel> Children { get; set; }






    }
}