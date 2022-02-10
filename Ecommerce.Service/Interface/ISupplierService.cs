using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Interface
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> ToList();
        Task<Supplier> Find(Expression<Func<Supplier,bool>> expression);
        Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical, bool>> expression);
        Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical, bool>> expression);
        Task InsertSupplierJuridical(SupplierJuridical entity);
        Task InsertSupplierPhysical(SupplierPhysical entity);
        Task RemoveSupplier(Supplier entity);
        Task UpdateSupplier(Supplier entity);

        Task InsertPhone(Phone phone);
        Task RemovePhone(Phone phone);
        Task UpdatePhone(Phone phone);
        Task UpdateAddress(Address address);
    }
}