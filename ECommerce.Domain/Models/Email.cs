using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Email : Entity
    {
        public string EmailAddress { get; private set; }
        protected Email() {}
        public Email(string emailAddress)
        {
            SetEmail(emailAddress);
        }
        public void SetEmail(string emailAddress)
        {
            if(string.IsNullOrEmpty(emailAddress)) throw new DomainExceptions("the Email attribute cannot be null");
            EmailAddress = emailAddress;
        }
    }
}