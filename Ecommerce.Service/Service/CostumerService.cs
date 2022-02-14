using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<Costumer> Find(Expression<Func<Costumer, bool>> expression)
        {
            return await _costumerRepository.Find(expression);
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
        public async Task<IEnumerable<Costumer>> ToList()
        {
           return await _costumerRepository.ToList();
        }

        public  Task AddCostumer(Costumer costumer)
        {
            throw new NotImplementedException();
        }
        public Task InsertPurchases(IEnumerable<Purchases> purchases)
        {
            throw new NotImplementedException();
        }

        public Task InsertShoppingCart(IEnumerable<ShoppingCart> shoppingCart)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<Purchases>> PurchacesToList(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCostumer(Costumer costumer)
        {
            throw new NotImplementedException();
        }

        public Task RemovePurchases(Purchases purchases)
        {
            throw new NotImplementedException();
        }

        public Task RemoveShoppingCart(IEnumerable<ShoppingCart> shoppingCart)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateCostumer(Costumer costumer)
        {
            throw new NotImplementedException();
        }
    }
}