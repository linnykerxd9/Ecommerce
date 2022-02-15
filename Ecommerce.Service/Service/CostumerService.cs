using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.DTO;
using Ecommerce.Service.Interface;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Service
{
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;

        public CostumerService(ICostumerRepository costumerRepository)
        {
            _costumerRepository = costumerRepository;
        }

        public Task AddCostumer(CostumerDTO category)
        {
            throw new NotImplementedException();
        }

        public async Task<Costumer> Find(Expression<Func<Costumer, bool>> expression)
        {
            return await _costumerRepository.Find(expression);
        }

        public Task InsertPurchases(IEnumerable<PurchasesDTO> purchases)
        {
            throw new NotImplementedException();
        }

        public Task InsertShoppingCart(IEnumerable<ShoppingCartDTO> shoppingCart)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<Costumer>> Pagination(int page, int size, string query)
        {
            if(query == null)
            {
                return await _costumerRepository.Pagination(page,size);
            }else
            {
                return await _costumerRepository.Pagination(page,size,x => x.FullName.ToLower().Contains(query.ToLower()) || 
                                                                            x.Cpf == query || 
                                                                            x.Email.EmailAddress.ToLower().Contains(query.ToLower()));
            }
        }

        public Task<IEnumerable<Purchases>> PurchacesToList(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCostumer(CostumerDTO category)
        {
            throw new NotImplementedException();
        }

        public Task RemovePurchases(PurchasesDTO purchases)
        {
            throw new NotImplementedException();
        }

        public Task RemoveShoppingCart(IEnumerable<ShoppingCartDTO> shoppingCart)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Costumer>> ToList()
        {
           return await _costumerRepository.ToList();
        }

        public Task UpdateCostumer(CostumerDTO category)
        {
            throw new NotImplementedException();
        }
    }
}