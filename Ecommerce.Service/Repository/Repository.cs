using System;
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
    public abstract class Repository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        protected readonly ECommerceContext _context;
        protected Repository(ECommerceContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }
        public virtual async Task<Pagination<T>> Pagination(int page, int size, Expression<Func<T, bool>> expression = null)
        {
           IPagedList<T> listPagination;
           if(expression == null)
           {
               listPagination = await _context.Set<T>().ToPagedListAsync(page,size);
           }else{
               listPagination = await _context.Set<T>().Where(expression).ToPagedListAsync(page,size);
           }
           return new Pagination<T>(){
                List = listPagination.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = listPagination.TotalItemCount
           };
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            _context.Set<T>().Update(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public async Task<int> SaveChanges()
        {
           return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}