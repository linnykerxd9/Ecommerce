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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceContext context) : base(context)
        {
        }
         public async override  Task<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return await _context.Set<Product>().Include( x => x.Category)
                                                .Include(x => x.Images)
                                                .Include(x => x.Supplier)
                                                .Where(expression).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>> ToList()
        {
            return await _context.Product.Include( x => x.Category)
                                         .Include(x => x.Images)
                                         .Include(x => x.Supplier)
                                         .ToListAsync();
        }
        public async override Task<Pagination<Product>> Pagination(int page, int size, Expression<Func<Product, bool>> expression = null)
        {
            IPagedList<Product> listPagination;
           if(expression == null)
           {
               listPagination = await _context.Set<Product>().Include( x => x.Category)
                                                             .Include(x => x.Supplier)
                                                             .ToPagedListAsync(page,size);
           }else{
               listPagination = await _context.Set<Product>().Include( x => x.Category)
                                                             .Include(x => x.Supplier)
                                                             .Where(expression).ToPagedListAsync(page,size);
           }
           return new Pagination<Product>(){
                List = listPagination.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = listPagination.TotalItemCount
           };
        }
        public async Task InsertImage(Image image)
        {
            await _context.Image.AddAsync(image);
        }

        public Task RemoveImage(Image image)
        {
             _context.Image.Remove(image);
            return Task.CompletedTask;

        }

    }
}