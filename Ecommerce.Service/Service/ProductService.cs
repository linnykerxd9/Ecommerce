using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.Interface;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return await _productRepository.Find(expression);
        }
        public async Task<Pagination<Product>> Pagination(int page, int size, string query)
        {
            if(query == null)
            {
                return await _productRepository.Pagination(page,size);
            }else
            {
                return await _productRepository.Pagination(page,size,x => x.Name.ToLower().Contains(query.ToLower()) ||
                                                            x.Category.Name.ToLower().Contains(query.ToLower()) ||
                                                            x.Supplier.FantasyName.ToLower().Contains(query.ToLower()) ||
                                                            x.BarCode.Contains(query));
            }
        }
        public async Task<IEnumerable<Product>> ToList()
        {
            return await _productRepository.ToList();
        }

        public Task InsertImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Task InsertProduct(Product entity)
        {
            throw new NotImplementedException();
        }


        public Task RemoveImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProduct(Product entity)
        {
            throw new NotImplementedException();
        }


        public Task UpdateProduct(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}