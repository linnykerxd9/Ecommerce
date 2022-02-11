using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.Data;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Ecommerce.Service.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceContext context) : base(context)
        {
        }
        public async override  Task<Category> Find(Expression<Func<Category, bool>> expression)
        {
            return await _context.Set<Category>().Include(x => x.Products).Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> ToList()
        {
            return await _context.Category.ToListAsync();
        }
    }
}