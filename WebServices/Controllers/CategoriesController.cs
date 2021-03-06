﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Data;
using Data.Entities;
using Data.Repositories;
using AutoMapper;
using Expense_WebSite_MobileApp.Models;
using Expense_WebSite_MobileApp.Models.CategoryModel;


namespace Expense_WebSite_MobileApp.Controllers
{
    public class CategoriesController : ApiController
    {
        public CategoriesController() { }
        public CategoriesController(ICategoryRepository repository
            , IMapper mapper
            )
        {
            Repository = repository;
            Mapper = mapper;
        }

        private ICategoryRepository Repository;
        private IMapper Mapper;
        // GET: api/Categories




        // [Authorize]
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var lst = Repository.GetAll(1);
            IEnumerable<CategoryViewModel> restLst = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(lst);
            return restLst;

        }

        // GET: api/Categories/5
        //[ResponseType(typeof(Category))]
        //public async Task<IHttpActionResult> GetCategory(long id)
        //{
        //    Category category = await db.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(category);
        //}

        //// PUT: api/Categories/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutCategory(long id, Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != category.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Categories
        //[ResponseType(typeof(Category))]
        //public async Task<IHttpActionResult> PostCategory(Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Categories.Add(category);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        //}

        //// DELETE: api/Categories/5
        //[ResponseType(typeof(Category))]
        //public async Task<IHttpActionResult> DeleteCategory(long id)
        //{
        //    Category category = await db.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Categories.Remove(category);
        //    await db.SaveChangesAsync();

        //    return Ok(category);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool CategoryExists(long id)
        //{
        //    return db.Categories.Count(e => e.Id == id) > 0;
        //}
    }
}