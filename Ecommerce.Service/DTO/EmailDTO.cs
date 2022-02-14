using System;

namespace Ecommerce.Service.DTO
{
    public class EmailDTO : EntityDTO
    {
        public string EmailAddress { get; set; }
        public Guid SupplierId { get; set; }

        public EmailDTO(string emailAddress, Guid supplierId)
        {
            EmailAddress = emailAddress;
            SupplierId = supplierId;
        }
    }
}