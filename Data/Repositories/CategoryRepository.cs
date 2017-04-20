using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Data.Entities;
using System.Data.Entity;

namespace Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Category Add(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long categoryId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db.Dispose(); 
        }

        public Category Edit(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll(long userId)
        {
            return db.Categories.Include(a => a.Children).Include(a=>a.Icon).Where(c => c.UserId == userId || c.UserId == null).ToList();
        }

        public IEnumerable<Category> GetByFilter(long userId, Expression<Func<Category, bool>> predicate)
        {
            return db.Categories.Where(c => c.UserId == userId || c.UserId == null).Where(predicate).ToList();
        }

        public Category GetById(long categoryId)
        {
            return db.Categories.Where(c => c.Id == categoryId).SingleOrDefault();
            
        }

        public Category GetByKey(string categoryKey)
        {
            return db.Categories.Where(c => c.Key == categoryKey).SingleOrDefault();
        }
    }
}