using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface ICostumerRepository: IRepository<Costumer>
    {
        Task<IEnumerable<Costumer>> ToList();
        Task<ShoppingCart> FindShoppingCart(Expression<Func<ShoppingCart, bool>> expression);
        Task InsertShoppingCart(ShoppingCart shoppingCart);
        Task UpdateShoppingCart(ShoppingCart shoppingCart);
        Task RemoveShoppingCart(ShoppingCart shoppingCart);
        Task RemoveAllItemsShoppingCart(IEnumerable<ShoppingCart> shoppingCart);
        Task InsertPurchases(IEnumerable<Purchases> purchases);
        Task RemovePurchases(Purchases purchases);
        Task<IEnumerable<Purchases>> PurchacesToList(Guid id);
        Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id);
    }
}