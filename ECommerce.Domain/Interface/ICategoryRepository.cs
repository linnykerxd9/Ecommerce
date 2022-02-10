using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<IEnumerable<Category>> ToList();
         
    }
}