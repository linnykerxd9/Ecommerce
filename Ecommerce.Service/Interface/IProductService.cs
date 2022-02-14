using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.DTO;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Interface
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ToList();
        Task<Product> Find(Expression<Func<Product,bool>> expression);
        Task<Pagination<Product>> Pagination(int page, int size, string query);
         Task InsertImage(ImageDTO image);
         Task RemoveImage(ImageDTO image);
        Task InsertProduct(PlatformID entity);
        Task RemoveProduct(PlatformID entity);
        Task UpdateProduct(PlatformID entity);
    }
}