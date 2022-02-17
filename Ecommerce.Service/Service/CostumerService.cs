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
            AddErrorNotificationForCostumer(costumer);
             if(_notificationService.HAsError())
                return;
            var costumerExists =  await _costumerRepository.Find(x => x.Cpf.Contains(costumer.Cpf) ||
                                                          x.Email.EmailAddress == costumer.Email.EmailAddress);
            if(costumerExists != null)
            {
                if(costumerExists.Cpf == costumer.Cpf)
                    _notificationService.AddError("Cpf already registered");

                if(costumerExists.Email.EmailAddress == costumer.Email.EmailAddress)
                    _notificationService.AddError("Email address already registered");
                return;
            }
            await _costumerRepository.Insert(costumer.ToDomain());
            await _costumerRepository.SaveChanges();
        }
        public async Task RemoveCostumer(CostumerDTO costumer)
        {
            AddErrorNotificationForCostumer(costumer);
            if(_notificationService.HAsError())
                return;
            var costumerExists = await _costumerRepository.Find(x => x.Cpf == costumer.Cpf);
            if(costumerExists == null)
            {
                _notificationService.AddError("Costumer not exists");
                return;
            }
            await _costumerRepository.Remove(costumerExists);
            await _costumerRepository.SaveChanges();
        }
        public async Task UpdateCostumer(CostumerDTO costumer)
        {
            AddErrorNotificationForCostumer(costumer);
             if(_notificationService.HAsError())
                return;
            var costumerExists = await _costumerRepository.Find(x => x.Cpf == costumer.Cpf);
            if(costumerExists == null)
            {
                _notificationService.AddError("Costumer not exists");
                return;
            }
            costumerExists.SetCpf(costumer.Cpf);
            costumerExists.SetFullName(costumer.FullName);

            await _costumerRepository.Update(costumerExists);
            await _costumerRepository.SaveChanges();
        }
        public async Task InsertPurchases(ICollection<PurchasesDTO> purchases)
        {
            foreach (var item in purchases)
            {
                if(item.CustomersId == Guid.Empty)
                    _notificationService.AddError("there is no buyer for this product");
                if(item.ProductId == Guid.Empty)
                    _notificationService.AddError("There is no product for this purchase");
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
            ICollection<Purchases> purchasesListDomain = new List<Purchases>();
            ICollection<ShoppingCartDTO> shopingCart = new List<ShoppingCartDTO>();
            foreach (var item in purchases)
            {
                purchasesListDomain.Add(item.ToDomain());
                shopingCart.Add(new ShoppingCartDTO(item.Quantity,item.TotalPrice,item.CustomersId,item.ProductId));
            }
            await RemoveAllItemsShoppingCart(shopingCart);
            if(_notificationService.HAsError())
                return;
            await _costumerRepository.InsertPurchases(purchasesListDomain);
            await _costumerRepository.SaveChanges();
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
            var costumerExists = await _costumerRepository.Find(x => x.Id == shoppingCart.CustomersId);
            if(costumerExists == null){
                _notificationService.AddError("Costumer not exists");
                return;
            }
            await _costumerRepository.InsertShoppingCart(shoppingCart.ToDomain());
            await _costumerRepository.SaveChanges();
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
            var costumerExists = await _costumerRepository.FindShoppingCart(x => x.Id == shoppingCart.CustomersId);
            if(costumerExists == null){
                _notificationService.AddError("Product not exists");
                return;
            }
            costumerExists.SetQuantity(shoppingCart.Quantity);
            costumerExists.SetTotalPrice(shoppingCart.TotalPrice);
            await _costumerRepository.InsertShoppingCart(costumerExists);
            await _costumerRepository.SaveChanges();
        }
        public async Task RemoveShoppingCart(ShoppingCartDTO shoppingCart)
        {
            if(!shoppingCart.Validate().IsValid)
            {
                foreach (var error in shoppingCart.Validate().Errors)
                {
                    _notificationService.AddError(error.ErrorMessage);
                }
                return;
            }
            await _costumerRepository.RemoveShoppingCart(shoppingCart.ToDomain());
            await _costumerRepository.SaveChanges();
        }
        private async Task RemoveAllItemsShoppingCart(ICollection<ShoppingCartDTO> shoppingCart)
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
            ICollection<ShoppingCart> shoppingCartListDomain = new List<ShoppingCart>();
            foreach (var item in shoppingCart)
            {
                shoppingCartListDomain.Add(item.ToDomain());
            }
            await _costumerRepository.RemoveAllItemsShoppingCart(shoppingCartListDomain);
            await _costumerRepository.SaveChanges();
        }
        private void AddErrorNotificationForCostumer(CostumerDTO costumer)
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
        }

        
    }
}