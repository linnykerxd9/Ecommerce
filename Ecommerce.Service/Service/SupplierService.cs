using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        public async Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task InsertPhone(Phone phone)
        {
            throw new NotImplementedException();
        }

        public Task InsertSupplierJuridical(SupplierJuridical entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertSupplierPhysical(SupplierPhysical entity)
        {
            throw new NotImplementedException();
        }

        public Task RemovePhone(Phone phone)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSupplier(Supplier entity)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePhone(Phone phone)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSupplier(Supplier entity)
        {
            throw new NotImplementedException();
        }

    }
}