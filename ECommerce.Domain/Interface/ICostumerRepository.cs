using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface ICostumerRepository: IRepository<Costumer>
    {
        Task<IEnumerable<Costumer>> ToList();
        Task InsertShoppingCart(IEnumerable<ShoppingCart> shoppingCart);
        Task InsertPurchases(IEnumerable<Purchases> purchases);
        Task RemoveShoppingCart(IEnumerable<ShoppingCart> shoppingCart);
        Task RemovePurchases(Purchases purchases);
        Task<IEnumerable<Purchases>> PurchacesToList(Guid id);
        Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id);
    }
}