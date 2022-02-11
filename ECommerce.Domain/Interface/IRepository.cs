using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> Find(Expression<Func<T,bool>> expression);
        Task<Pagination<T>> Pagination(int page, int size, Expression<Func<T, bool>> expression = null);
        Task Insert(T entity);
        Task Remove(T entity);
        Task Update(T entity);
        Task<int> SaveChanges();
    }
}