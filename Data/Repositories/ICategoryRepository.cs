using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
   public interface ICategoryRepository:IDisposable
    {
        IEnumerable<Category> GetAll(long userId);

        IEnumerable<Category> GetByFilter(long userId, Expression<Func<Category, bool>> predicate );
        Category GetByKey(string categoryKey);
        Category GetById(long categoryId);

        Category Add(Category category);

        Category Edit(Category category);

        bool Delete(long categoryId);

        //as result of D/E/A, can create a class with success or error and list of errors
    }
}
