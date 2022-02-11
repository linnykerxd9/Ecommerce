using System;
using System.Collections.Generic;
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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ECommerceContext context) : base(context)
        {
        }
        public async override  Task<Supplier> Find(Expression<Func<Supplier, bool>> expression)
        {
            return await _context.Set<Supplier>().Include(x => x.Email)
                                                 .Include(x => x.Phone)
                                                 .Include(x => x.Product)
                                                 .Where(expression)
                                                 .FirstOrDefaultAsync();
        }
        public async Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical, bool>> expression)
        {
            return await _context.SupplierJuridical.Include(x => x.Email)
                                                   .Include(x => x.Phone)
                                                   .Include(x => x.Product)
                                                   .Where(expression)
                                                   .FirstOrDefaultAsync();
        }

        public async Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical, bool>> expression)
        {
            return await _context.SupplierPhysical.Include(x => x.Email)
                                                  .Include(x => x.Phone)
                                                  .Include(x => x.Product)
                                                  .Where(expression)
                                                  .FirstOrDefaultAsync();
        }
        public async override Task<Pagination<Supplier>> Pagination(int page, int size, Expression<Func<Supplier, bool>> expression = null)
        {
            IPagedList<Supplier> listPagination;
           if(expression == null)
           {
               listPagination = await _context.Set<Supplier>().Include(x => x.Email)
                                                              .Include(x => x.Phone)
                                                              .ToPagedListAsync(page,size);
           }else{
               listPagination = await _context.Set<Supplier>().Include(x => x.Email)
                                                              .Include(x => x.Phone)
                                                              .Where(expression)
                                                              .ToPagedListAsync(page,size);
           }
           return new Pagination<Supplier>(){
                List = listPagination.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = listPagination.TotalItemCount
           };
        }
        public async Task<IEnumerable<Supplier>> ToList()
        {
            return await _context.Supplier.Include(x => x.Email)
                                          .Include(x => x.Phone)
                                          .Include(x => x.Product)
                                          .ToListAsync();
        }

        public async Task InsertPhone(Phone phone)
        {
            await _context.Phone.AddAsync(phone);
        }

        public Task RemovePhone(Phone phone)
        {
            _context.Phone.Remove(phone);
            return Task.CompletedTask;
        }

        public Task UpdatePhone(Phone phone)
        {
            _context.Phone.Update(phone).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public Task UpdateAddress(Address address)
        {
            _context.Address.Update(address).State = EntityState.Modified;
            return Task.CompletedTask;
        }

    }
}