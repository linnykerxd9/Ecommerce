using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Interface
{
    public interface ICostumerService
    {
         Task<IEnumerable<Costumer>> ToList();
        Task<Costumer> Find(Expression<Func<Costumer, bool>> expression);
        Task<Pagination<Costumer>> Pagination(int page, int size, string query);
         Task AddCostumer(Costumer category);
         Task RemoveCostumer(Costumer category);
         Task UpdateCostumer(Costumer category);
         Task InsertShoppingCart(IEnumerable<ShoppingCart> shoppingCart);
        Task InsertPurchases(IEnumerable<Purchases> purchases);
        Task RemoveShoppingCart(IEnumerable<ShoppingCart> shoppingCart);
        Task RemovePurchases(Purchases purchases);
        Task<IEnumerable<Purchases>> PurchacesToList(Guid id);
        Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id);
    }
}