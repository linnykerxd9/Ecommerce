using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Interface
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ToList();
        Task<Product> Find(Expression<Func<Product,bool>> expression);
        Task<Pagination<Costumer>> Pagination(int page, int size, string query);
         Task InsertImage(Image image);
         Task RemoveImage(Image image);
        Task InsertProduct(Product entity);
        Task RemoveProduct(Product entity);
        Task UpdateProduct(Product entity);
    }
}