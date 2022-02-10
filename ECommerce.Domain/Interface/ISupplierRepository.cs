using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<SupplierJuridical> FindJuridical(Expression<Func<SupplierJuridical, bool>> expression);
        Task<SupplierPhysical> FindPhysical(Expression<Func<SupplierPhysical, bool>> expression);
        Task<IEnumerable<Supplier>> ToList();
        Task UpdateAddress(Address address);

        Task InsertPhone(Phone phone);
        Task RemovePhone(Phone phone);
        Task UpdatePhone(Phone phone);
    }
}