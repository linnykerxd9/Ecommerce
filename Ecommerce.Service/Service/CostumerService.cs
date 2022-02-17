using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.DTO;
using Ecommerce.Service.Interface;
using Ecommerce.Service.Tools;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Service
{
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly NotificationService _notificationService;

        public CostumerService(ICostumerRepository costumerRepository, NotificationService notificationService)
        {
            _costumerRepository = costumerRepository;
            _notificationService = notificationService;
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
        public async Task<IEnumerable<ShoppingCart>> ShoppingCartToList(Guid id)
        {
            return await _costumerRepository.ShoppingCartToList(id);
        }


        public async Task<IEnumerable<Purchases>> PurchacesToList(Guid id)
        {
            return await _costumerRepository.PurchacesToList(id);

        }
        public async Task AddCostumer(CostumerDTO costumer)
        {
            if(!costumer.Validate().IsValid)
            {
                if(costumer.Cpf.IsCpf())
                    _notificationService.AddError("Cpf invalid");
                foreach (var erro in costumer.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }
        public async Task RemoveCostumer(CostumerDTO costumer)
        {
            if(!costumer.Validate().IsValid)
            {
                if(costumer.Cpf.IsCpf())
                    _notificationService.AddError("Cpf invalid");
                foreach (var erro in costumer.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }
        public async Task UpdateCostumer(CostumerDTO costumer)
        {
            if(!costumer.Validate().IsValid)
            {
                foreach (var erro in costumer.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }
        public async Task InsertPurchases(ICollection<PurchasesDTO> purchases)
        {
            foreach (var item in purchases)
            {
                if(!item.Validate().IsValid)
                {
                    foreach (var error in item.Validate().Errors)
                    {
                        _notificationService.AddError(error.ErrorMessage);
                    }
                }
            }
            if(_notificationService.HAsError())
                return;
            throw new NotImplementedException();
        }
        public async Task InsertShoppingCart(ShoppingCartDTO shoppingCart)
        {
                if(!shoppingCart.Validate().IsValid)
                {
                    foreach (var error in shoppingCart.Validate().Errors)
                    {
                        _notificationService.AddError(error.ErrorMessage);
                    }
                return; 
                }
            throw new NotImplementedException();
        }
        public async Task UpdateItemShoppingCart(ShoppingCartDTO shoppingCart)
        {
             if(!shoppingCart.Validate().IsValid)
                {
                    foreach (var error in shoppingCart.Validate().Errors)
                    {
                        _notificationService.AddError(error.ErrorMessage);
                    }
                return; 
                }
            throw new NotImplementedException();
        }
        public  async Task RemoveAllItemsShoppingCart(ICollection<ShoppingCartDTO> shoppingCart)
        {
            foreach (var item in shoppingCart)
            {
                if(!item.Validate().IsValid)
                {
                    foreach (var error in item.Validate().Errors)
                    {
                        _notificationService.AddError(error.ErrorMessage);
                    }
                }
            }
            if(_notificationService.HAsError())
                return;
            throw new NotImplementedException();
        }

    }
}