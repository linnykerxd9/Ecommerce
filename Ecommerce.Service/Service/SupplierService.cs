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

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
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

        public Task InsertSupplierJuridical(SupplierJuridicalDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertSupplierPhysical(SupplierPhysicalDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSupplier(SupplierDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSupplier(SupplierDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertPhone(PhoneDTO phone)
        {
            throw new NotImplementedException();
        }

        public Task RemovePhone(PhoneDTO phone)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePhone(PhoneDTO phone)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAddress(AddressDTO address)
        {
            throw new NotImplementedException();
        }
    }
}