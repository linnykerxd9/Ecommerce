using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Phone : Entity
    {
        public string Ddd { get; private set; }
        public string Number { get; private set; }
        public Guid SupplierId { get; set; }
        protected Phone() { }
        public Phone(string ddd, string number, Guid supplierId)
        {
            SetDdd(ddd);
            SetNumber(number);
            SetSupplierId(supplierId);
        }
        public void SetDdd(string ddd){
            if(string.IsNullOrEmpty(ddd))
             throw new DomainExceptions("DDD is invalid");

             Ddd = ddd;
        }

        public void SetNumber(string number){
            if(string.IsNullOrEmpty(number))
            throw new DomainExceptions("Number is invalid");
            Number = number;
        }
        public void SetSupplierId(Guid Id)
        {
            if(Id == Guid.Empty) throw new DomainExceptions("the Supplier Id attribute cannot be null");
            SupplierId = Id;
        }
    }
}