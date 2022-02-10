using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.Domain.Interface
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> Find(Expression<Func<T,bool>> expression);
        Task Insert(T entity);
        Task Remove(T entity);
        Task Update(T entity);
        Task<int> SaveChanges();
    }
}