using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ToList();
        Task<Category> Find(Expression<Func<Category, bool>> expression);
        Task<Pagination<Category>> Pagination(int page, int size, string query);
         Task AddCategory(Category category);
         Task RemoveCategory(Category category);
         Task UpdateCategory(Category category);
    }
}