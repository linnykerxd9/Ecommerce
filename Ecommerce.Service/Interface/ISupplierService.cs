using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Service.DTO;
using ECommerce.Domain.Models;

namespace Ecommerce.Service.Interface
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> ToList();
        Task<Pagination<Supplier>> Pagination(int page, int size, string query);
        Task<Supplier> Find(Expression<Func<Supplier,bool>> expression);
        Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical, bool>> expression);
        Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical, bool>> expression);
        Task InsertSupplierJuridical(SupplierJuridicalDTO entity);
        Task InsertSupplierPhysical(SupplierPhysicalDTO entity);
        Task RemoveSupplier(SupplierDTO entity);
        Task UpdateSupplier(SupplierDTO entity);

        Task InsertPhone(PhoneDTO phone);
        Task RemovePhone(PhoneDTO phone);
        Task UpdatePhone(PhoneDTO phone);
        Task UpdateAddress(AddressDTO address);
    }
}