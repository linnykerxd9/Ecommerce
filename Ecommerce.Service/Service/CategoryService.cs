using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.Interface;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Find(Expression<Func<Category, bool>> expression)
        {
            return await _categoryRepository.Find(expression);
        }

        public async Task<Pagination<Category>> Pagination(int page, int size, string query)
        {
            if(query == null)
            {
                return await _categoryRepository.Pagination(page,size);
            }else
            {
                return await _categoryRepository.Pagination(page,size,x => x.Name.ToLower().Contains(query.ToLower()));
            }
        }
        public async Task<IEnumerable<Category>> ToList()
        {
            return await _categoryRepository.ToList();
        }
        public Task AddCategory(Category category)
        {
            throw new NotImplementedException();
        }


        public Task RemoveCategory(Category category)
        {
            throw new NotImplementedException();
        }


        public Task UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}