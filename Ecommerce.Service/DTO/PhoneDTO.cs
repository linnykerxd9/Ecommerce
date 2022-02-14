using System;

namespace Ecommerce.Service.DTO
{
    public class PhoneDTO : EntityDTO
    {
         public string Ddd { get;  set; }
        public string Number { get;  set; }
        public Guid SupplierId { get; set; }

        public PhoneDTO(string ddd, string number, Guid supplierId)
        {
            Ddd = ddd;
            Number = number;
            SupplierId = supplierId;
        }
    }
}