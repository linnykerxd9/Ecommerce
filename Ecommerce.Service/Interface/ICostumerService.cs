using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.DTO;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Interface
{
    public interface ICostumerService
    {
         Task<IEnumerable<Costumer>> ToList();
        Task<Costumer> Find(Expression<Func<Costumer, bool>> expression);
        Task<Pagination<Costumer>> Pagination(int page, int size, string query);
         Task AddCostumer(CostumerDTO category);
         Task RemoveCostumer(CostumerDTO category);
         Task UpdateCostumer(CostumerDTO category);
         Task InsertShoppingCart(IEnumerable<ShoppingCartDTO> shoppingCart);
        Task RemoveShoppingCart(IEnumerable<ShoppingCartDTO> shoppingCart);
        Task InsertPurchases(IEnumerable<PurchasesDTO> purchases);
        Task RemovePurchases(PurchasesDTO purchases);
        Task<IEnumerable<Purchases>> PurchacesToList(Guid id);
        Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id);
    }
}