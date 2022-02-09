using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Phone : Entity
    {
        public string Ddd { get; private set; }
        public string Number { get; private set; }
        protected Phone() { }
        public Phone(string ddd, string number)
        {
            SetDdd(ddd);
            SetNumber(number);
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
    }
}