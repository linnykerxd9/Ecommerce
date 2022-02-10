using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> ToList();
         Task InsertImage(Image image);
         Task RemoveImage(Image image);
    }
}