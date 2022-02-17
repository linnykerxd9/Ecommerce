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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly NotificationService _notificationService;

        public SupplierService(ISupplierRepository supplierRepository, NotificationService notificationService)
        {
            _supplierRepository = supplierRepository;
            _notificationService = notificationService;
        }

        public async Task<Supplier> Find(Expression<Func<Supplier, bool>> expression)
        {
            return await _supplierRepository.Find(expression);
        }
        public async Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical, bool>> expression)
        {
            return await _supplierRepository.FindJuridical(expression);
        }

        public async Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical, bool>> expression)
        {
            return await _supplierRepository.FindPhysical(expression);
        }
        public async Task<IEnumerable<Supplier>> ToList()
        {
            return await _supplierRepository.ToList();
        }

        public async Task<Pagination<Supplier>> Pagination(int page, int size, string query)
        {
            if(query == null)
            {
                return await _supplierRepository.Pagination(page,size);
            }else
            {
                return await _supplierRepository.Pagination(page,size,x => x.FantasyName.ToLower().Contains(query.ToLower()));
            }
        }

        public async Task InsertSupplierJuridical(SupplierJuridicalDTO entity)
        {
             if(!entity.Validate().IsValid)
            {
                foreach (var erro in entity.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public async Task InsertSupplierPhysical(SupplierPhysicalDTO entity)
        {
             if(!entity.Validate().IsValid)
            {
                foreach (var erro in entity.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public async Task RemoveSupplier(SupplierDTO entity)
        {
            if(!entity.Validate().IsValid)
            {
                foreach (var erro in entity.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }

            throw new NotImplementedException();
        }

        public async Task UpdateSupplier(SupplierDTO entity)
        {
             if(!entity.Validate().IsValid)
            {
                foreach (var erro in entity.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public async Task InsertPhone(PhoneDTO phone)
        {
             if(!phone.Validate().IsValid)
            {
                foreach (var erro in phone.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public async Task RemovePhone(PhoneDTO phone)
        {
             if(!phone.Validate().IsValid)
            {
                foreach (var erro in phone.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public async Task UpdatePhone(PhoneDTO phone)
        {
             if(!phone.Validate().IsValid)
            {
                foreach (var erro in phone.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }

        public async Task UpdateAddress(AddressDTO address)
        {
             if(!address.Validate().IsValid)
            {
                foreach (var erro in address.Validate().Errors)
                {
                    _notificationService.AddError(erro.ErrorMessage);
                }
                return;
            }
            throw new NotImplementedException();
        }
    }
}