using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Email : Entity
    {
        public string EmailAddress { get; private set; }
        public Guid SupplierId { get; set; }
        protected Email() {}
        public Email(string emailAddress, Guid supplierId)
        {
            SetEmail(emailAddress);
            SetSupplierId(supplierId);
        }
        public void SetEmail(string emailAddress)
        {
            if(string.IsNullOrEmpty(emailAddress)) throw new DomainExceptions("the Email attribute cannot be null");
            EmailAddress = emailAddress;
        }
        public void SetSupplierId(Guid Id)
        {
            if(Id == Guid.Empty) throw new DomainExceptions("the Supplier Id attribute cannot be null");
            SupplierId = Id;
        }
    }
}