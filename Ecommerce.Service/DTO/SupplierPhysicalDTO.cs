using System;
using System.Collections.Generic;

namespace Ecommerce.Service.DTO
{
    public class SupplierPhysicalDTO : SupplierDTO
    {
        public string FullName { get;  set; }
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }
        public SupplierPhysicalDTO(string fullName, string cpf, DateTime birthDate,bool active,
                                   string fantasyName, EmailDTO email, AddressDto address,
                                    ICollection<PhoneDTO> phone) : base(active, fantasyName, email, address, phone)
        {
            FullName = fullName;
            Cpf = cpf;
            BirthDate = birthDate;
        }
    }
}