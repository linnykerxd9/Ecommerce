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
    public class CostumerRepository : Repository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(ECommerceContext context) : base(context)
        {
        }
        public async override  Task<Costumer> Find(Expression<Func<Costumer, bool>> expression)
        {
            return await _context.Set<Costumer>().Include(x => x.Email).Where(expression).FirstOrDefaultAsync();
        }
        public async override Task<Pagination<Costumer>> Pagination(int page, int size, Expression<Func<Costumer, bool>> expression = null)
        {
            IPagedList<Costumer> listPagination;
           if(expression == null)
           {
               listPagination = await _context.Set<Costumer>().Include(x => x.Email).ToPagedListAsync(page,size);
           }else{
               listPagination = await _context.Set<Costumer>().Include(x => x.Email).Where(expression).ToPagedListAsync(page,size);
           }
           return new Pagination<Costumer>(){
                List = listPagination.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = listPagination.TotalItemCount
           };
        }
        public async Task<IEnumerable<Costumer>> ToList()
        {
            return await _context.Costumer.Include( x => x.Email).ToListAsync();
        }
        public async Task<IEnumerable<Purchases>> PurchacesToList(Guid id)
        {
            return await _context.Purchases.Include(x => x.Product)
                                              .ThenInclude(x => x.Supplier)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id)
        {
            return await _context.ShoppingCart.Include(x => x.Product)
                                              .ThenInclude(x => x.Supplier)
                                              .ToListAsync();
        }

        public async Task InsertPurchases(IEnumerable<Purchases> purchases)
        {
            await _context.Purchases.AddRangeAsync(purchases);
        }

        public async Task InsertShoppingCart(IEnumerable<ShoppingCart> shoppingCart)
        {
            await _context.ShoppingCart.AddRangeAsync(shoppingCart);
        }

        public Task RemovePurchases(Purchases purchase)
        {
            _context.Purchases.Remove(purchase);
            return Task.CompletedTask;
        }

        public Task RemoveShoppingCart(IEnumerable<ShoppingCart> shoppingCart)
        {
            _context.ShoppingCart.RemoveRange(shoppingCart);
            return Task.CompletedTask;
        }


    }
}