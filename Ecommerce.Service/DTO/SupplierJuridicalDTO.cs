using System;
using System.Collections.Generic;

namespace Ecommerce.Service.DTO
{
    public class SupplierJuridicalDTO : SupplierDTO
    {
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime OpenDate { get; set; }

        public SupplierJuridicalDTO(string companyName, string cnpj, DateTime openDate,bool active,
                                    string fantasyName, EmailDTO email, AddressDto address,
                                    ICollection<PhoneDTO> phone) : base(active, fantasyName, email, address, phone)
        {
            CompanyName = companyName;
            Cnpj = cnpj;
            OpenDate = openDate;
        }
    }
}