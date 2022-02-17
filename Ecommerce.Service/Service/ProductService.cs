using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.DTO;
using Ecommerce.Service.Interface;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly NotificationService _notificationService;

        public ProductService(IProductRepository productRepository, NotificationService notificationService)
        {
            _productRepository = productRepository;
            _notificationService = notificationService;
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

        public Task InsertImage(ImageDTO image)
        {
            throw new NotImplementedException();
        }

        public async Task InsertProduct(ProductDTO entity)
        {
            if(!entity.Validate().IsValid)
            {
                foreach (var erro in entity.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public Task RemoveImage(ImageDTO image)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveProduct(ProductDTO entity)
        {
            if(!entity.Validate().IsValid)
            {
                foreach (var erro in entity.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> ToList()
        {
            return await _productRepository.ToList();
        }

        public async Task UpdateProduct(ProductDTO entity)
        {
            if(!entity.Validate().IsValid)
            {
                foreach (var erro in entity.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }
    }
}